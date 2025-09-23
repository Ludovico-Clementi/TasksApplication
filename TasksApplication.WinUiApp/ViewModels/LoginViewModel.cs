using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TasksApplication.DataModels.Models;
using TasksApplication.WinUiAPP.Services;
using System.Threading.Tasks;
using System.Windows.Input;
using TasksApplication.WinUiAPP.Views;

namespace TasksApplication.WinUiAPP.ViewModels;

public partial class LoginViewModel : ObservableObject
{
    private readonly UserService _userService;
    private readonly NavigationService _navigationService;

    public LoginViewModel(NavigationService navigationService)
    {
        _userService = new UserService("https://localhost:7101");
        _navigationService = navigationService;
    }

    [ObservableProperty]
    private string nomeUtente = string.Empty;

    [ObservableProperty]
    private string passwordUtente = string.Empty;


    [RelayCommand]
    public async Task Register()
    {
        var newUser = new User { Name = NomeUtente, Password = PasswordUtente };
        var success = await _userService.RegisterUser(newUser);

        if (success)
            await DialogService.ShowAsync("Registered", $"Welcome {NomeUtente}!");
        else
            await DialogService.ShowAsync("Error", "Something went wrong.");

        NomeUtente = string.Empty;
        PasswordUtente = string.Empty;
    }

    [RelayCommand]
    public async Task Login()
    {
        var currUser = new User { Name = NomeUtente, Password = PasswordUtente };
        var result = await _userService.CheckLoginValidity(currUser);
        bool success = result.Success;

        if (success)
        {
            var nome = NomeUtente;
            NomeUtente = string.Empty;
            PasswordUtente = string.Empty;

            await DialogService.ShowAsync("Login Completed", $"✅ Welcome back {nome}!");

            SessionService.CurrentUser = currUser;
            SessionService.CurrentUser.Id = result.NewId;
            _navigationService.Navigate(typeof(MenuPage));

        }
        else
        {
            await DialogService.ShowAsync("Login Error", "❌ Your password or your username are wrong.");
        }
    }
}
