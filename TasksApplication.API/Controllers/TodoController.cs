using Microsoft.AspNetCore.Mvc;
using TasksApplication.DataModels.Data;
using Microsoft.EntityFrameworkCore;
using TasksApplication.DataModels.Models;
using Microsoft.AspNetCore.Http.HttpResults;
namespace TasksApplication.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly AppDbContext _db;
    public TodoController(AppDbContext db) => _db = db;

    [HttpGet]
    public async Task<IEnumerable<Todo>> GetAllTasks() => await _db.Todos.ToListAsync();

    [HttpGet("{userId}")]
    public async Task<IEnumerable<Todo>> GetUserTasks(int userId)
    {
        return await _db.Todos.Where(t => t.UserId == userId)
                             .ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult> AddTask(Todo todo)
    {
        todo.StartDate = DateTime.SpecifyKind(todo.StartDate, DateTimeKind.Utc);
        if (todo.DueDate.HasValue)
            todo.DueDate = DateTime.SpecifyKind(todo.DueDate.Value, DateTimeKind.Utc);

        _db.Todos.Add(todo);
        await _db.SaveChangesAsync();
        return new OkObjectResult(todo);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        var todo = new Todo { Id = id };
        _db.Todos.Attach(todo);
        _db.Todos.Remove(todo);
        await _db.SaveChangesAsync();

        return Ok();
    }

    [HttpPut("{id}/complete")]
    public async Task<ActionResult<Todo>> MarkCompleted(int id)
    {
        _db.Todos.Where(t => t.Id == id)
                 .ExecuteUpdate(t => t.SetProperty(t => t.Completed, true));
        return Ok();
    }
}
