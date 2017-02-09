using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Web.Domain.Entities
{
    public class Todo
    {
        protected Todo() { }

        public Todo(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public int Id { get; private set; }

        public string Title { get; private set; }
        public string Description { get; private set; }
    }
}
