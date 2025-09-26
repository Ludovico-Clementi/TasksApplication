using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TasksApplication.DataModels.Models;
using TasksApplication.Core.Services;

namespace TasksApplication.Core.ViewModels;

public partial class LoginViewModel : ObservableObject
{
    private readonly UserService _userService;
    private readonly INavigationService _navigationService;
    private readonly IDialogService _dialogService;

    public LoginViewModel(INavigationService navigationService, IDialogService dialogService)
    {
        _userService = new UserService("https://localhost:7101");
        _navigationService = navigationService;
        _dialogService = dialogService;
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
            await _dialogService.ShowAsync("Registered", $"Welcome {NomeUtente}!");
        else
            await _dialogService.ShowAsync("Error", "Something went wrong.");

        NomeUtente = string.Empty;
        PasswordUtente = string.Empty;
        }

    [RelayCommand]
    public async Task Login()
    {
        var currUser = new User { Name = NomeUtente, Password = PasswordUtente };
        var result = await _userService.CheckLoginValidity(currUser);

        if (result.Success)
        {
            var nome = NomeUtente;
            NomeUtente = string.Empty;
            PasswordUtente = string.Empty;

            await _dialogService.ShowAsync("Login Completed", $"✅ Welcome back {nome}!");

            SessionService.CurrentUser = currUser;
            SessionService.CurrentUser.Id = result.NewId;

            _navigationService.Navigate("MenuPage");

        }
        else
        {
            await _dialogService.ShowAsync("Login Error", "❌ Wrong credentials.");
        }
    }
}
