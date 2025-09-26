using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Threading.Tasks;
using TasksApplication.Core.Services;

namespace TasksApplication.WinUIApp.Services;

public class WinUIDialogService : IDialogService
{
    private readonly XamlRoot _xamlRoot;
    public WinUIDialogService(XamlRoot xamlRoot) => _xamlRoot = xamlRoot;

    public async Task ShowAsync(string title, string message)
    {
        var dialog = new ContentDialog
        {
            Title = title,
            Content = message,
            CloseButtonText = "OK",
            XamlRoot = _xamlRoot
        };

        await dialog.ShowAsync();
    }
}
