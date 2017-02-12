using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Todo.Web.Domain.Services;
using Todo.Web.Domain.Validatiors;

namespace Todo.Web.Controllers
{
    [Route("api/[controller]")]
    public class TodosController : Controller
    {
        private readonly TodoService _todoService;

        public TodosController(TodoService todoService)
        {
            _todoService = todoService;
        }

        // GET api/todos
        [HttpGet]
        public IEnumerable<Domain.Entities.Todo> Get()
        {
            return _todoService.List();
        }

        // GET api/todos/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var todo = _todoService.Find(id);

            if (todo is null)
            {
                return NotFound();
            }

            return Ok(todo);
        }

        // POST api/todos
        [HttpPost]
        public IActionResult Post([FromBody]Domain.Entities.Todo todo)
        {
            todo.Id = 0;

            ValidationResult validation = _todoService.Create(todo);

            if (validation.IsValid)
            {
                return Ok();
            }

            return StatusCode(422, validation.Errors);
        }

        // PUT api/todos/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Domain.Entities.Todo todo)
        {
            var savedTodo = _todoService.Find(id);

            if (savedTodo == null)
            {
                return NotFound();
            }

            savedTodo.Change(todo);

            ValidationResult validation = _todoService.Update(savedTodo);

            if (validation.IsValid)
            {
                return Ok();
            }

            return StatusCode(422, validation.Errors);
        }

        // DELETE api/todos/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todo = _todoService.Find(id);

            if (todo == null)
            {
                return NotFound();
            }

            _todoService.Delete(todo);

            return Ok();
        }
    }
}
