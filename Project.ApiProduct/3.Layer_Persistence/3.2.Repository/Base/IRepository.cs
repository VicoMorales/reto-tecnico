using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.ApiProduct._3.Layer_Persistence._3._2.Repository.Base
{
    public interface IRepository<T> where T : class
    {
        bool Delete(T entity);
        bool Update(T entity);
        int Insert(T entity);
        IEnumerable<T> GetList();
        T GetById(int id);
    }
}
