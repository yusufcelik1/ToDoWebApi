using DataAccessLayer.Models;
using DataAccessLayer;
using BusinessLayer.Interfaces;
namespace BusinessLayer.Services
{
    public class ToDoItemService : IToDoItemService
    {
        private readonly AppDbContext _context;

        public ToDoItemService(AppDbContext context)
        {
            _context = context;
        }

        // Get ToDoItem by ID (Read)
        public ToDoItem GetToDoItemById(int id)
        {
            return _context.TodoItems.FirstOrDefault(t => t.ID == id);
        }

        // Create a new ToDoItem
        public ToDoItem CreateToDoItem(ToDoItem todoItem)
        {
            if (todoItem != null)
            {
                _context.TodoItems.Add(todoItem);
                _context.SaveChanges();
                
            }
            return todoItem;
        }

        // Update an existing ToDoItem
        public ToDoItem UpdateToDoItem(ToDoItem todoItem)
        {
            var existingToDoItem = _context.TodoItems.FirstOrDefault(t => t.ID == todoItem.ID);

            if (existingToDoItem != null)
            {
                existingToDoItem.Description = todoItem.Description;
                existingToDoItem.Note = todoItem.Note;
                existingToDoItem.DateCreated = todoItem.DateCreated;
                existingToDoItem.TimeCreated = todoItem.TimeCreated;
                existingToDoItem.IsCompleted = todoItem.IsCompleted;
                // Add other fields if necessary

                _context.SaveChanges();

                return existingToDoItem;
            }
            return null;
        }

        // Delete a ToDoItem
        public bool DeleteToDoItem(int id)
        {
            var toDoItemToDelete = _context.TodoItems.FirstOrDefault(t => t.ID == id);

            if (toDoItemToDelete != null)
            {
                _context.TodoItems.Remove(toDoItemToDelete);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        // Get all ToDoItems (optional, based on your needs)
        public List<ToDoItem> GetAllToDoItems()
        {
            return _context.TodoItems.ToList();
        }

        // Get all ToDoItems for a specific user (optional, if you want this feature)
        public List<ToDoItem> GetAllToDoItemsByUserId(int userId)
        {
            return _context.TodoItems.Where(t => t.UserID == userId).ToList();
        }
    }
}
