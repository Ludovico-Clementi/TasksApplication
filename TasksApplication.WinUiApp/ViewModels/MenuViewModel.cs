using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TasksApplication.DataModels.Models;
using TasksApplication.WinUiAPP.Services;
using System.Threading.Tasks;
using System.Windows.Input;
using TasksApplication.WinUiAPP.Views;

namespace TasksApplication.WinUiAPP.ViewModels;

public partial class MenuViewModel : ObservableObject
{
    //private readonly UserService _userService;
    private readonly NavigationService _navigationService;

    public MenuViewModel(NavigationService navigationService)
    {
        //_userService = new UserService("https://localhost:7267");
        _navigationService = navigationService;
    }

    //[RelayCommand]  
    //public void GoToLogin()
    //{
    //    _navigationService.Navigate(typeof(LoginPage));
    //}

    //[RelayCommand]
    //public void GoToTodoList()
    //{
    //    _navigationService.Navigate(typeof(TodoListPage));
    //}

}
