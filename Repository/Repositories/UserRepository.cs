using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Repository.Repositories.UserRepository;

namespace Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IContext _context;
        public UserRepository(IContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetById(string id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
        }

        public async Task<User> Add(User model)
        {
            var user = _context.Users.Add(model);
            await _context.SaveChangesAsync();
            return user.Entity;
        }

        public async Task<User> Update(User entity)
        {
            var user = _context.Users.Update(entity);
            await _context.SaveChangesAsync();
            return user.Entity;
        }

        public async Task Delete(string id)
        {
            _context.Users.Remove(await GetById(id));
            await _context.SaveChangesAsync();
        }
        //public async Task Delete(string id)
        //{
        //    var children = await _context.Children.Where(c => c.UserId == id).ToListAsync();
        //    _context.Children.RemoveRange(children);
        //    var user = await GetById(id);
        //    _context.Users.Remove(user);
        //    await _context.SaveChangesAsync();
        //}
    }
}