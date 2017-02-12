using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Web.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        IList<T> List();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
