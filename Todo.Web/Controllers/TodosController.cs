using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Todo.Web.Domain.Services;
using FluentValidation.Results;

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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/todos/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/todos
        [HttpPost]
        public IActionResult Post([FromBody]Domain.Entities.Todo todo)
        {
            ValidationResult result = _todoService.Create(todo);

            if (result.IsValid)
            {
                return Ok();
            }

            return StatusCode(422, result.Errors);
        }

        // PUT api/todos/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/todos/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
