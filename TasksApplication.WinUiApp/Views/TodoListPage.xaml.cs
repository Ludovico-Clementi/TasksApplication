using Microsoft.UI.Xaml.Controls;
using TasksApplication.Core.Services;
using TasksApplication.Core.ViewModels;
using TasksApplication.WinUIApp.Services;

namespace TasksApplication.WinUIApp.Views;

public sealed partial class TodoListPage : Page
{
    public TodoListPage()
    {
        this.InitializeComponent();

        this.Loaded += TodoListPage_Loaded;
    }

    private void TodoListPage_Loaded(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        this.Loaded -= TodoListPage_Loaded;

        // Ora XamlRoot è valido 
        var dialogService = new WinUIDialogService(this.XamlRoot);
        var navService = new WinUINavigationService(this.Frame);

        this.DataContext = new TodoListViewModel(dialogService,navService);
    }

    private void MenuButton_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        this.Frame.Navigate(typeof(MenuPage));
    }
}
