using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Interfaces;
using DataAccessLayer.Models;
using System.Collections.Generic;

namespace EvoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoItemController : ControllerBase
    {
        private readonly IToDoItemService _toDoItemService;

        public ToDoItemController(IToDoItemService toDoItemService)
        {
            _toDoItemService = toDoItemService;
        }

        // GET: api/ToDoItem
        [HttpGet("GetAllToDoItems")]
        public ActionResult<IEnumerable<ToDoItem>> GetToDoItems()
        {
            return Ok(_toDoItemService.GetAllToDoItems());
        }

        // GET: api/ToDoItem/5
        [HttpGet("GetToDoItemByID")]
        public ActionResult<ToDoItem> GetToDoItem(int id)
        {
            var toDoItem = _toDoItemService.GetToDoItemById(id);
            if (toDoItem == null)
            {
                return NotFound();
            }
            return Ok(toDoItem);
        }

        // POST: api/ToDoItem
        [HttpPost("CreateToDoItem")]
        public ActionResult<ToDoItem> PostToDoItem(ToDoItem? toDoItem)
        {
            
            var createdToDoItem = _toDoItemService.CreateToDoItem(toDoItem);
            return CreatedAtAction(nameof(GetToDoItem), new { id = createdToDoItem.ID }, createdToDoItem);
        }

        // PUT: api/ToDoItem/5
        [HttpPut("UpdateToDoItem")]
        public IActionResult PutToDoItem(int id, ToDoItem toDoItem)
        {
            if (id != toDoItem.ID)
            {
                return BadRequest();
            }
            var updatedToDoItem = _toDoItemService.UpdateToDoItem(toDoItem);
            if (updatedToDoItem == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/ToDoItem/5
        [HttpDelete("DeleteToDoItem")]
        public IActionResult DeleteToDoItem(int id)
        {
            var result = _toDoItemService.DeleteToDoItem(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
