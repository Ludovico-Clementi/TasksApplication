using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using System;
using System.Threading.Tasks;

namespace TasksApplication.WinUiAPP.Services;

public static class DialogService
{
    public static XamlRoot XamlRoot { get; set; }

    public static async Task ShowAsync(string title, string message)
    {
        if (XamlRoot == null)
            throw new InvalidOperationException("DialogService XamlRoot non impostato.");

        var dialog = new ContentDialog
        {
            Title = title,
            Content = message,
            CloseButtonText = "OK",
            XamlRoot = XamlRoot
        };

        await dialog.ShowAsync();
    }
}
