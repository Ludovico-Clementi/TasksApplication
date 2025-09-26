using TasksApplication.Core.ViewModels;
using TasksApplication.MauiApps.Services;

namespace TasksApplication.MauiApps.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();

        var navService = new MauiNavigationService();
        var dialogService = new MauiDialogService();

        BindingContext = new LoginViewModel(navService, dialogService);
    }
}
