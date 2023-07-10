using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ISevices<T>
    {
        Task<T> Add(T model);
        Task<T> Update(T model);
        Task Delete(string id);
        Task<T> GetById(string id);
        Task<List<T>> GetAll();
    }
}
