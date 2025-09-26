using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TasksApplication.API.Controllers;
using TasksApplication.DataModels.Models;
using TasksApplication.APIControllerTesting.Helpers;
using Xunit;

namespace TasksApplication.Tests
{
    public class TodoControllerTests
    {
        [Fact]
        public async Task GetAllTasks_ReturnsAllTodos()
        {
            var db = DbContextHelper.GetInMemoryDbContext();
            db.Todos.Add(new Todo { Title = "Task 1", UserId = 1 });
            db.Todos.Add(new Todo { Title = "Task 2", UserId = 2 });
            await db.SaveChangesAsync();

            var controller = new TodoController(db);

            var result = await controller.GetAllTasks();

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetUserTasks_ReturnsOnlyUserTodos()
        {
            var db = DbContextHelper.GetInMemoryDbContext();
            db.Todos.Add(new Todo { Title = "Task 1", UserId = 1 });
            db.Todos.Add(new Todo { Title = "Task 2", UserId = 2 });
            await db.SaveChangesAsync();

            var controller = new TodoController(db);

            var result = await controller.GetUserTasks(1);

            Assert.Single(result);
            Assert.Equal(1, result.First().UserId);
        }

        [Fact]
        public async Task AddTask_StoresTodoAndReturnsOk()
        {
            var db = DbContextHelper.GetInMemoryDbContext();
            var controller = new TodoController(db);

            var newTask = new Todo
            {
                Title = "Nuovo Task",
                UserId = 1,
                StartDate = DateTime.UtcNow
            };

            var result = await controller.AddTask(newTask);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedTask = Assert.IsType<Todo>(okResult.Value);

            Assert.Equal("Nuovo Task", returnedTask.Title);
            Assert.Single(db.Todos);
        }

        [Fact]
        public async Task DeleteTask_RemovesTodo()
        {
            var db = DbContextHelper.GetInMemoryDbContext();
            var task = new Todo { Title = "Da eliminare", UserId = 1, StartDate = DateTime.UtcNow };
            db.Todos.Add(task);
            await db.SaveChangesAsync();

            var controller = new TodoController(db);

            var result = await controller.DeleteTask(task.Id);

            Assert.IsType<OkResult>(result);
            Assert.Empty(db.Todos);
        }

        [Fact]
        public async Task MarkCompleted_SetsTodoAsCompleted()
        {
            var db = DbContextHelper.GetInMemoryDbContext();
            var task = new Todo { Title = "Da completare", UserId = 1, StartDate = DateTime.UtcNow, Completed = false };
            db.Todos.Add(task);
            await db.SaveChangesAsync();

            var controller = new TodoController(db);

            var result = await controller.MarkCompleted(task.Id);

            // Assert sul tipo OkObjectResult
            var okResult = Assert.IsType<OkObjectResult>(result.Result);

            // Controllo sul contenuto
            var returnedTodo = Assert.IsType<Todo>(okResult.Value);
            Assert.True(returnedTodo.Completed);

            // Controllo che anche nel db sia aggiornato
            var updatedTask = db.Todos.First(t => t.Id == task.Id);
            Assert.True(updatedTask.Completed);
        }

    }
}
