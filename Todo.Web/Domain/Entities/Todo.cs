using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Attributes;

namespace Todo.Web.Domain.Entities
{
    public class Todo
    {
        public Todo() { }

        public Todo(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public Todo(int id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
        }

        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public void Change(Todo todo)
        {
            Title = todo.Title;
            Description = todo.Description;
        }
    }
}
