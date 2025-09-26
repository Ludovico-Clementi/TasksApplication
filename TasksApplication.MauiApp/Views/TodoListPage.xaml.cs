using TasksApplication.Core.ViewModels;
using TasksApplication.MauiApps.Services;

namespace TasksApplication.MauiApps.Views;

public partial class TodoListPage : ContentPage
{
    public TodoListPage()
    {
        InitializeComponent();

        var dialogService = new MauiDialogService();
        var navService = new MauiNavigationService();

        BindingContext = new TodoListViewModel(dialogService);
    }
}
