using AutoMapper;
using Entity.Entities;
using Repository.Interfaces;
using Service.Models;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository repository;
        private readonly IMapper mapper;
        public UserService(IUserRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<List<UserModel>> GetAll()
        {
            return mapper.Map<List<UserModel>>(await repository.GetAll());
            //List<User> list =await repository.GetAll();
            //List<UserModel> listToReturn = new List<UserModel>();
            //foreach (var item in list)
            //{
            //    listToReturn.Add(mapper.Map<UserModel>(item));
            //}
            //return listToReturn; 
        }

        public async Task<UserModel> GetById(string id)
        {
            return mapper.Map<UserModel>(await repository.GetById(id));
        }

        public async Task<UserModel> Add(UserModel model)
        {
            return mapper.Map<UserModel>(await repository.Add(mapper.Map<User>(model)));
        }

        public async Task<UserModel> Update(UserModel model)
        {
            return mapper.Map<UserModel>(await repository.Update(mapper.Map<User>(model)));
        }

        public async Task Delete(string id)
        {
            await repository.Delete(id);
        }
    }
}


