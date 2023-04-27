using CubatelToDoListApp.API.Request;
using CubatelToDoListApp.Contracts.Exceptions;
using CubatelToDoListApp.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CubatelToDoListApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        private readonly IToDoListService _service;

        public ToDoListController(IToDoListService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get() {
            try
            {
                var res = _service.GetAllTasks();
                return Ok(res);
            }
            catch (ToDoListException tex)
            {
                var res = new
                {
                    Error = tex.Message
                };
                return BadRequest(res);
            }
            catch (Exception)
            {
                var res = new
                {
                    Error = "Error interno, intente mas tarde "
                };
                return StatusCode(500, res);
            }

        }

        [HttpPost]
        public IActionResult Create([FromBody] TaskRequest newTask)
        {
            try
            {
                var res = _service.CreateTask(newTask.Name, newTask.Description);
                return Ok(res);
            }
            catch (ToDoListException tex)
            {
                var res = new
                {
                    Error = tex.Message
                };
                return BadRequest(res);
            }
            catch (Exception)
            {
                var res = new
                {
                    Error = "Error interno, intente mas tarde " 
                };
                return StatusCode(500, res);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] TaskRequest task)
        {
            try
            {
                var taskToEdit = new Contracts.Models.TaskDto { Name = task.Name, Description = task.Description };
                var res = _service.EditTask(id,taskToEdit);

                return Ok(res);
            }
            catch (ToDoListException tex)
            {
                var res = new
                {
                    Error = tex.Message
                };
                return BadRequest(res);
            }
            catch (Exception)
            {
                var res = new
                {
                    Error = "Error interno, intente mas tarde "
                };
                return StatusCode(500, res);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var res = _service.DeleteTask(id);

                return Ok(res);
            }
            catch (ToDoListException tex)
            {
                var res = new
                {
                    Error = tex.Message
                };
                return BadRequest(res);
            }
            catch (Exception)
            {
                var res = new
                {
                    Error = "Error interno, intente mas tarde "
                };
                return StatusCode(500, res);
            }
        }
    }
}
