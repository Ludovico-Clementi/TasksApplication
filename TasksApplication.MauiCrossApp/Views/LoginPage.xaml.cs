using TasksApplication.Core.ViewModels;

namespace TasksApplication.MauiCrossApp.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
