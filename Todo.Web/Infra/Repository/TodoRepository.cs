using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Web.Infra.Context;

namespace Todo.Web.Infra.Repository
{
    public class TodoRepository : Repository<Domain.Entities.Todo>
    {
        public TodoRepository(DataContext context) : base(context)
        {
        }
    }
}
