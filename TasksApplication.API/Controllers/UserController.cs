using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TasksApplication.DataModels.Data;
using TasksApplication.DataModels.Models;

namespace TasksApplication.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly AppDbContext _db;
    public UserController(AppDbContext db) => _db = db;

    [HttpGet("All")]
    public async Task<IEnumerable<User>> GetAllUsers() => await _db.Users.ToListAsync();

    [HttpPost("register")]
    public async Task<ActionResult<User>> Register(User user)
    {
        if (string.IsNullOrWhiteSpace(user.Name) || string.IsNullOrWhiteSpace(user.Password))
        {
            return BadRequest("Nome utente e password obbligatori.");
        }

        // TODO: hash password qui
        _db.Users.Add(user);
        await _db.SaveChangesAsync();

        return Ok(user);
    }


    //[HttpDelete("{id}")]
    //public async Task<IActionResult> DeleteUser(int id)
    //{
    //    var user = new User { Id = id };
    //    _db.Users.Attach(user);
    //    _db.Users.Remove(user);
    //    await _db.SaveChangesAsync();

    //    return Ok();
    //}
}
