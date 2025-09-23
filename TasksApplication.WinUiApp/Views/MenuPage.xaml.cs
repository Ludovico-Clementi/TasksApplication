using TasksApplication.WinUiAPP.Services;
using TasksApplication.WinUiAPP.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

namespace TasksApplication.WinUiAPP.Views
{
    public sealed partial class MenuPage : Page
    {
        private readonly NavigationService _navigationService;

        public MenuPage()
        {
            this.InitializeComponent();
            greetingDisplay.Text = $"Hello, {SessionService.CurrentUser.Name}!";
        }

        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{
        //    base.OnNavigatedTo(e);

        //    // Recupera il NavigationService passato come parametro
        //    var navigationService = e.Parameter as NavigationService;

        //    // Imposta il DataContext con il ViewModel, includendo NavigationService
        //    this.DataContext = new MenuViewModel(navigationService);
        //}

        private void ExitButton_Click(object sender, RoutedEventArgs e) => Application.Current.Exit();

        private void TodoListButton_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TodoListPage));
        }
    }
}
