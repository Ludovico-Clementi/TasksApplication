using TasksApplication.DataModels.Models;

namespace TasksApplication.Core.Services;

public static class SessionService
{
    public static User CurrentUser { get; set; } = new User();
}
