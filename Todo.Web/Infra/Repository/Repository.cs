using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Web.Domain.Interfaces;
using Todo.Web.Infra.Context;

namespace Todo.Web.Infra.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> List()
        {
            return _context.Set<T>().ToList();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
