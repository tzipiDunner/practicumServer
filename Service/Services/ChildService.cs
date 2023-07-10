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
    public class ChildService : IChildService
    {
        private readonly IChildRepository repository;
        private readonly IMapper mapper;
        public ChildService(IChildRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<List<ChildModel>> GetAll()
        {
            return mapper.Map<List<ChildModel>>(await repository.GetAll());
            //List<Child> list = await repository.GetAll();
            //List<ChildModel> listToReturn = new List<ChildModel>();
            //foreach (var item in list)
            //{
            //    listToReturn.Add(mapper.Map<ChildModel>(item));
            //}
            //return listToReturn;
        }

        public async Task<ChildModel> GetById(string id)
        {
            return mapper.Map<ChildModel>(await repository.GetById(id));
        }

        public async Task<ChildModel> Add(ChildModel model)
        {
            return mapper.Map<ChildModel>(await repository.Add(mapper.Map<Child>(model)));
        }

        public async Task<ChildModel> Update(ChildModel model)
        {
            return mapper.Map<ChildModel>(await repository.Update(mapper.Map<Child>(model)));
        }

        public async Task Delete(string id)
        {
            await repository.Delete(id);
        }
    }
}