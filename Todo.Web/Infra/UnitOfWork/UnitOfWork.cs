using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Web.Domain.Interfaces;
using Todo.Web.Infra.Context;
using Todo.Web.Infra.Repository;

namespace Todo.Web.Infra.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private bool _disposed;

        private readonly DataContext _context;
        private TodoRepository _todoRepository;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public TodoRepository TodoRepository
        {
            get
            {
                if (_todoRepository == null)
                {
                    _todoRepository = new TodoRepository(_context);
                }
                return _todoRepository;
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
