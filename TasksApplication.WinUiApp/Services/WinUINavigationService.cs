using Microsoft.UI.Xaml.Controls;
using TasksApplication.Core.Services;
using TasksApplication.WinUIApp.Views;

namespace TasksApplication.WinUIApp.Services;

public class WinUINavigationService : INavigationService
{
    private readonly Frame _frame;
    public WinUINavigationService(Frame frame) => _frame = frame;

    public void Navigate(string route)
    {
        switch (route)
        {
            case "MenuPage":
                _frame.Navigate(typeof(MenuPage));
                break;
            case "TodoListPage":
                _frame.Navigate(typeof(TodoListPage));
                break;
        }
    }
}
