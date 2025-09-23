using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using TasksApplication.WinUiAPP.Services;
// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TasksApplication.WinUiAPP.Views;

/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainWindow : Window
{
    public NavigationService NavigationService { get; }

    public MainWindow()
    {
        InitializeComponent();

        NavigationService = new NavigationService(MainFrame);
        MainFrame.Navigate(typeof(LoginPage), NavigationService);


        var rootElement = this.Content as FrameworkElement;
        if (rootElement != null)
            rootElement.Loaded += Root_Loaded;
    }
    private void Root_Loaded(object sender, RoutedEventArgs e)
    {
        DialogService.XamlRoot = this.Content.XamlRoot;
    }
}
