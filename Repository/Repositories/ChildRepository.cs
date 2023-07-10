using Azure;
using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ChildRepository : IChildRepository
    {
        private readonly IContext _context;
        public ChildRepository(IContext context)
        {
            _context = context;
        }

        public async Task<List<Child>> GetAll()
        {
            return await _context.Children.ToListAsync();
        }

        public async Task<Child> GetById(string id)
        {
            return await _context.Children.FindAsync(id);
        }

        public async Task<Child> Add(Child model)
        {
            var child = _context.Children.Add(model);
            await _context.SaveChangesAsync();
            return child.Entity;
        }

        public async Task<Child> Update(Child model)
        {
            var child = _context.Children.Update(model);
            await _context.SaveChangesAsync();
            return child.Entity;
        }

        public async Task Delete(string id)
        {
            _context.Children.Remove(await GetById(id));
            await _context.SaveChangesAsync();
        }
    }
}