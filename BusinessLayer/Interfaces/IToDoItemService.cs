using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IToDoItemService
    {
        ToDoItem GetToDoItemById(int id);
        ToDoItem CreateToDoItem(ToDoItem todoItem);
        ToDoItem UpdateToDoItem(ToDoItem todoItem);
        bool DeleteToDoItem(int id);
        List<ToDoItem> GetAllToDoItems();
        List<ToDoItem> GetAllToDoItemsByUserId(int userId);
    }
}
