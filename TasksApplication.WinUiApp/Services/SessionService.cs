using TasksApplication.DataModels.Models;

namespace TasksApplication.WinUiAPP.Services;

public static class SessionService
{
    public static User? CurrentUser { get; set; }
}
