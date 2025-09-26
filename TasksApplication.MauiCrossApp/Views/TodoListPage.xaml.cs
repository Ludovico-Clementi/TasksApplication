using TasksApplication.Core.ViewModels;

namespace TasksApplication.MauiCrossApp.Views;

public partial class TodoListPage : ContentPage
{
    public TodoListPage(TodoListViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
