using CubatelToDoListApp.API.Request;
using CubatelToDoListApp.Contracts.Exceptions;
using CubatelToDoListApp.Contracts.Models;
using CubatelToDoListApp.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CubatelToDoListApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListItemController : ControllerBase
    {
        private readonly IToDoListItemService _service;

        public ToDoListItemController(IToDoListItemService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult AddItem([FromBody] TaskItemRequest taskItem)
        {
            try
            {
                var res = _service.AddItemToAList(taskItem.TaskId, taskItem.Name, taskItem.Description);
                return Ok(res);
            }
            catch (ToDoListItemException tex)
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
        public IActionResult EditItem(int id, [FromBody] TaskItemToEditRequest taskItem)
        {
            try
            {
                var item = new TaskItemDto { Name = taskItem.Name, Description = taskItem.Description };
                var res = _service.EditItem(id, item);
                return Ok(res);
            }
            catch (ToDoListItemException tex)
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
        public IActionResult RemoveItem(int id)
        {
            try
            {
                var res = _service.RemoveItem(id);
                return Ok(res);
            }
            catch (ToDoListItemException tex)
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

        [HttpPatch("{id}")]
        public IActionResult CompleteItem(int id)
        {
            try
            {
                var res = _service.CompleteItem(id);
                return Ok(res);
            }
            catch (ToDoListItemException tex)
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

        [HttpPatch("{id}/{taskId}")]
        public IActionResult MoveItem(int id, int taskId)
        {
            try
            {
                var res = _service.MoveItemToATask(id, taskId);
                return Ok(res);
            }
            catch (ToDoListItemException tex)
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
