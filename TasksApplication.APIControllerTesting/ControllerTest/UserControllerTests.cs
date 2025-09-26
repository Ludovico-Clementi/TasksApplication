using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TasksApplication.API.Controllers;
using TasksApplication.DataModels.Models;
using TasksApplication.APIControllerTesting.Helpers;
using Xunit;

namespace TasksApplication.APIControllerTesting.Controllers
{
    public class UserControllerTests
    {
        [Fact]
        public async Task GetAllUsers_ReturnsAllUsers()
        {
            var db = DbContextHelper.GetInMemoryDbContext();
            db.Users.Add(new User { Name = "Mario", Password = "pwd123" });
            db.Users.Add(new User { Name = "Luca", Password = "pwd456" });
            await db.SaveChangesAsync();

            var controller = new UserController(db);

            var result = await controller.GetAllUsers();

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task Register_ValidUser_ReturnsOk()
        {
            var db = DbContextHelper.GetInMemoryDbContext();
            var controller = new UserController(db);

            var newUser = new User { Name = "Giovanni", Password = "pwd789" };
            var result = await controller.Register(newUser);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedUser = Assert.IsType<User>(okResult.Value);
            Assert.Equal("Giovanni", returnedUser.Name);
        }

        [Fact]
        public async Task Register_InvalidUser_ReturnsBadRequest()
        {
            var db = DbContextHelper.GetInMemoryDbContext();
            var controller = new UserController(db);

            var invalidUser = new User { Name = "", Password = "" };
            var result = await controller.Register(invalidUser);

            Assert.IsType<BadRequestObjectResult>(result.Result);
        }
    }
}
