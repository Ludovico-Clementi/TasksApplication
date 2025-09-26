using TasksApplication.Core.Services;

namespace TasksApplication.MauiCrossApp.Services;

public class MauiDialogService : IDialogService
{
    public Task ShowAsync(string title, string message)
    {
        return Application.Current.MainPage.DisplayAlert(title, message, "OK");
    }
}
