using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using TasksApplication.Core.Services;
using TasksApplication.Core.ViewModels;
using TasksApplication.WinUIApp.Services;

namespace TasksApplication.WinUIApp.Views;

public sealed partial class MenuPage : Page
{
    public MenuPage()
    {
        this.InitializeComponent();

        // Crea i servizi WinUI
        var navService = new WinUINavigationService(this.Frame);
        var dialogService = new WinUIDialogService(this.XamlRoot);

        // Inietta ViewModel
        this.DataContext = new MenuViewModel(navService, dialogService);

        // Aggiorna greeting
        greetingDisplay.Text = $"Hello, {SessionService.CurrentUser.Name}!";
    }

    private void ExitButton_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Exit();
    }

    private void TodoListButton_Click(object sender, RoutedEventArgs e)
    {
        this.Frame.Navigate(typeof(TodoListPage));
    }
}
