using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Web.Domain.Validatiors.Todo;
using Todo.Web.Infra.UnitOfWork;
using Todo.Web.Domain.Validatiors;

namespace Todo.Web.Domain.Services
{
    public class TodoService
    {
        private readonly UnitOfWork _unitOfWork;

        public TodoService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ValidationResult Create(Entities.Todo todo)
        {
            TodoValidator validator = new TodoValidator(todo);

            if (validator.IsValid)
            {
                _unitOfWork.TodoRepository.Add(todo);
                _unitOfWork.SaveChanges();
            }

            return validator.Results;
        }

        public ValidationResult Update(Entities.Todo todo)
        {
            UpdateTodoValidator validator = new UpdateTodoValidator(todo);

            if (validator.IsValid)
            {
                _unitOfWork.TodoRepository.Update(todo);
                _unitOfWork.SaveChanges();
            }

            return validator.Results;
        }

        public IList<Entities.Todo> List()
        {
            return _unitOfWork.TodoRepository.List();
        }

        public void Delete(Entities.Todo todo)
        {
            _unitOfWork.TodoRepository.Delete(todo);
            _unitOfWork.SaveChanges();
        }

        public Entities.Todo Find(int id)
        {
            return _unitOfWork.TodoRepository.GetById(id);;
        }
    }
}
