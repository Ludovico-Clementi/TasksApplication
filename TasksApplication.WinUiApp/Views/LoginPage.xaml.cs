using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using TasksApplication.Core.ViewModels;

namespace TasksApplication.WinUIApp.Views;

public sealed partial class LoginPage : Page
{
    public LoginPage()
    {
        InitializeComponent();
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);

        if (e.Parameter is LoginViewModel vm)
            DataContext = vm;
    }
}
