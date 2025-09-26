using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TasksApplication.DataModels.Models;
using TasksApplication.Core.Services;

namespace TasksApplication.Core.ViewModels;

public partial class TodoListViewModel : ObservableObject
{
    private readonly TodoService _todoService;
    private readonly IDialogService _dialogService;
    private readonly INavigationService _navigationService;

    public TodoListViewModel(IDialogService dialogService, INavigationService navigationService)
    {
        _todoService = new TodoService("https://localhost:7101");
        _dialogService = dialogService;
        _navigationService = navigationService;
        Todos = new ObservableCollection<Todo>();
        _ = LoadTodosAsync();
    }

    [ObservableProperty] private Todo _selectedTodo;
    [ObservableProperty] private string title = string.Empty;
    [ObservableProperty] private string description = string.Empty;
    [ObservableProperty] private DateTimeOffset startDate = DateTime.Now;
    [ObservableProperty] private DateTimeOffset dueDate = DateTime.Now;
    [ObservableProperty] private ObservableCollection<Todo> todos;

    [RelayCommand]
    public async Task LoadTodosAsync()
    {
        var list = await _todoService.GetTodosOfUser();
        Todos.Clear();
        foreach (var t in list) Todos.Add(t);
    }

    [RelayCommand]
    public async Task AddNewTodoAsync()
    {
        var newTodo = new Todo
        {
            Id = 0,
            Title = Title,
            Description = Description,
            Completed = false,
            StartDate = StartDate.UtcDateTime,
            DueDate = DueDate.UtcDateTime,
            UserId = SessionService.CurrentUser.Id
        };

        var saved = await _todoService.AddTodo(newTodo);
        if (saved != null)
        {
            Todos.Add(saved);
            await _dialogService.ShowAsync("Success", $"Task {Title} added!");
        }
        else
        {
            await _dialogService.ShowAsync("Error", "Error adding task");
        }
    }

    [RelayCommand]
    public async Task DeleteTodoAsync()
    {
        if (SelectedTodo == null)
        {
            await _dialogService.ShowAsync("Error", "No task selected");
            return;
        }

        var todoToDelete = SelectedTodo; // ✅ salva prima in locale

        var deleted = await _todoService.DeleteTodo(todoToDelete.Id);
        if (deleted)
        {
            Todos.Remove(todoToDelete);
            await _dialogService.ShowAsync("Deleted", $"Task {todoToDelete.Title} deleted!");
        }
        else
        {
            await _dialogService.ShowAsync("Error", "Error deleting task");
        }
    }

}
