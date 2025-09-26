using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TasksApplication.Core.Services;

namespace TasksApplication.Core.ViewModels;

public partial class MenuViewModel : ObservableObject
{
    private readonly INavigationService _navigationService;
    private readonly IDialogService _dialogService;

    public MenuViewModel(INavigationService navigationService, IDialogService dialogService)
    {
        _navigationService = navigationService;
        _dialogService = dialogService;
    }

    public string Greeting => $"Hello, {SessionService.CurrentUser.Name}!";

    [RelayCommand]
    public void GoToTodoList()
    {
        _navigationService.Navigate("TodoListPage");
    }

    [RelayCommand]
    public async Task ExitAppAsync()
    {
        await _dialogService.ShowAsync("Exit", "Do you really want to exit?");
    }
}
