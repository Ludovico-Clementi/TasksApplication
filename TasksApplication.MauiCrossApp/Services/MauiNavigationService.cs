using TasksApplication.Core.Services;
using TasksApplication.MauiCrossApp.Views;
using Microsoft.Maui.Controls;

namespace TasksApplication.MauiCrossApp.Services;

public class MauiNavigationService : INavigationService
{
    // Ora Navigate è asincrono
    public async Task NavigateAsync(string route)
    {
        switch (route)
        {
            case "Menu":
                await Shell.Current.GoToAsync("menu");
                break;

            case "Login":
                await Shell.Current.GoToAsync("login");
                break;

            default:
                throw new ArgumentException($"Route '{route}' non registrata.");
        }
    }

    // Metodo sincrono per compatibilità con interfaccia precedente
    public void Navigate(string route)
    {
        _ = NavigateAsync(route); // ignora il warning
    }
}
