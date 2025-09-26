using Microsoft.Maui.Hosting;
using TasksApplication.Core.Services;
using TasksApplication.Core.ViewModels;
using TasksApplication.MauiApps.Services;

namespace TasksApplication.MauiApps
{
    public static class MauiProgram
    {
        public static MauiAppBuilder CreateMauiApp()
        {
            var builder = MauiAppBuilder.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            // DI
            builder.Services.AddSingleton<INavigationService, MauiNavigationService>();
            builder.Services.AddSingleton<IDialogService, MauiDialogService>();

            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<MenuViewModel>();
            builder.Services.AddTransient<TodoListViewModel>();

            return builder.Build();
        }
    }
}
