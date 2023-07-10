using AutoMapper;
using Entity.Entities;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Repository.Interfaces;
using Repository.Repositories;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public static class Extentions
    {
        public static void AddRepoDependencies(this IServiceCollection service)
        {
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IChildRepository, ChildRepository>();
            MapperConfiguration config = new MapperConfiguration(
                  conf =>
                  {
                      conf.CreateMap<User, UserModel>().ReverseMap();
                      conf.CreateMap<Child, ChildModel>().ReverseMap();
                  });
            IMapper mapper = config.CreateMapper();
            service.AddSingleton(mapper);
            service.AddDbContext<IContext, Context>();
        }
    }
}