using TasksApplication.Core.Services;
using TasksApplication.MauiApps.Views;

namespace TasksApplication.MauiApps.Services;

public class MauiNavigationService : INavigationService
{
    public void Navigate(string route)
    {
        switch (route)
        {
            case "Menu":
                Shell.Current.GoToAsync(nameof(MenuPage));
                break;
        }
    }
}
