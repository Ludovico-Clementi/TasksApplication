using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using TasksApplication.WinUiAPP.ViewModels;
using TasksApplication.WinUiAPP.Services;

namespace TasksApplication.WinUiAPP.Views;

public sealed partial class LoginPage : Page
{
    public LoginPage()
    {
        this.InitializeComponent();
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);

        // Recupera il NavigationService passato come parametro
        var navigationService = e.Parameter as NavigationService;

        // Imposta il DataContext con il ViewModel, includendo NavigationService
        this.DataContext = new LoginViewModel(navigationService);
    }


    
}
