using Microsoft.UI.Xaml.Controls;
using System;

namespace TasksApplication.WinUiAPP.Services;

public class NavigationService
{
    private readonly Frame _frame;

    public NavigationService(Frame frame)
    {
        _frame = frame;
    }

    public void Navigate(Type pageType)
    {
        _frame.Navigate(pageType);
    }
}
