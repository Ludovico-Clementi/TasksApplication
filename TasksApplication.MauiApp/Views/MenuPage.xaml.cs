using TasksApplication.Core.ViewModels;
using TasksApplication.MauiApps.Services;
using TasksApplication.MauiApps.Services;

namespace TasksApplication.MauiApps.Views;

public partial class MenuPage : ContentPage
{
    public MenuPage()
    {
        InitializeComponent();

        var navService = new MauiNavigationService();
        var dialogService = new MauiDialogService();

        BindingContext = new MenuViewModel(navService, dialogService);
    }
}
