using TasksApplication.MauiCrossApp.Views;

namespace TasksApplication.MauiCrossApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute("menu", typeof(MenuPage));
        Routing.RegisterRoute("todolist", typeof(TodoListPage));
    }
}
