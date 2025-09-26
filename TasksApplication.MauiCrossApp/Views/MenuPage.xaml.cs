using TasksApplication.Core.ViewModels;

namespace TasksApplication.MauiCrossApp.Views;

public partial class MenuPage : ContentPage
{
    public MenuPage(MenuViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
