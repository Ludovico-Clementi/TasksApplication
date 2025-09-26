using Microsoft.EntityFrameworkCore;
using TasksApplication.DataModels.Data;

namespace TasksApplication.APIControllerTesting.Helpers
{
    public static class DbContextHelper
    {
        public static AppDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()) // DB separato per ogni test
                .Options;

            return new AppDbContext(options);
        }
    }
}
