using Microsoft.EntityFrameworkCore;

namespace TasksApplication.DataModels.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Models.User> Users { get; set; }
    public DbSet<Models.Todo> Todos { get; set; }

}
