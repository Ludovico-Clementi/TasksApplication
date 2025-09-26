using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using TasksApplication.Core.ViewModels;
using TasksApplication.WinUIApp.Services;

namespace TasksApplication.WinUIApp.Views;

public sealed partial class MainWindow : Window
{
    public WinUINavigationService NavigationService { get; }
    public WinUIDialogService DialogService { get; private set; }

    public MainWindow()
    {
        InitializeComponent();
        NavigationService = new WinUINavigationService(MainFrame);

        if (this.Content is FrameworkElement root)
        {
            root.Loaded += Root_Loaded;
        }
    }

    private void Root_Loaded(object sender, RoutedEventArgs e)
    {
        if (sender is FrameworkElement root && root.XamlRoot != null)
        {
            ((FrameworkElement)sender).Loaded -= Root_Loaded;

            DialogService = new WinUIDialogService(root.XamlRoot);
            var loginViewModel = new LoginViewModel(NavigationService, DialogService);
            MainFrame.Navigate(typeof(LoginPage), loginViewModel);
        }
    }

}
