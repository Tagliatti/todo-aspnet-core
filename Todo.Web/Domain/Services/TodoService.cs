using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Web.Domain.Validatiors.Todo;
using Todo.Web.Infra.UnitOfWork;

namespace Todo.Web.Domain.Services
{
    public class TodoService
    {
        private readonly UnitOfWork _unitOfWork;

        public TodoService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ValidationResult Create(Domain.Entities.Todo todo)
        {
            CreateTodoValidator validator = new CreateTodoValidator(todo);

            if (validator.IsValid)
            {
                _unitOfWork.TodoRepository.Add(todo);
                _unitOfWork.SaveChanges();
            }

            return validator;
        }
    }
}
