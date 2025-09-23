using TasksApplication.WinUiAPP.ViewModels;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using TasksApplication.WinUiAPP.Services;

namespace TasksApplication.WinUiAPP.Views;

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class TodoListPage : Page
{
    public TodoListPage()
    {
        this.InitializeComponent();
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);

        // Recupera il NavigationService passato come parametro
        var navigationService = e.Parameter as NavigationService;

        // Imposta il DataContext con il ViewModel, includendo NavigationService
        this.DataContext = new TodoListViewModel(navigationService);
    }

    private void MenuButton_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        this.Frame.Navigate(typeof(MenuPage));
    }
}
