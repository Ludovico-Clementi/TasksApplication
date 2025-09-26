using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using TasksApplication.MauiCrossApp.Services;
using TasksApplication.Core.Services;
using TasksApplication.Core.ViewModels;
using TasksApplication.MauiCrossApp.Views;

namespace TasksApplication.MauiCrossApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        // Servizi
        builder.Services.AddSingleton<INavigationService, MauiNavigationService>();
        builder.Services.AddSingleton<IDialogService, MauiDialogService>();

        // ViewModel
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<MenuViewModel>();
        builder.Services.AddTransient<TodoListViewModel>();

        // Pagine
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<MenuPage>();
        builder.Services.AddTransient<TodoListPage>();

        return builder.Build();
    }
}
