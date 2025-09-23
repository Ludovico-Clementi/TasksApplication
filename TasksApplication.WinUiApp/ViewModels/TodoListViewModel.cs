using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TasksApplication.DataModels.Models;
using TasksApplication.WinUiAPP.Services;
using Microsoft.UI.Xaml.Controls;
using Microsoft.WindowsAppSDK.Runtime;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Services.Maps;

namespace TasksApplication.WinUiAPP.ViewModels
{
    public partial class TodoListViewModel : ObservableObject
    {
        private readonly TodoService _todoService;
        private readonly NavigationService _navigationService;

        public TodoListViewModel(NavigationService navigationService)
        {
            _todoService = new TodoService("https://localhost:7101");
            _navigationService = navigationService;

            Todos = new ObservableCollection<Todo>();

            CaricaTodosAsync();
        }

        private Todo _selectedTodo;
        public Todo SelectedTodo
        {
            get => _selectedTodo;
            set
            {
                _selectedTodo = value;
                OnPropertyChanged(nameof(SelectedTodo));
            }
        }


        [ObservableProperty]
        private string title = string.Empty;

        [ObservableProperty]
        private string description = string.Empty;

        [ObservableProperty]
        private DateTimeOffset startDate = DateTime.Now;

        [ObservableProperty]
        private DateTimeOffset dueDate = DateTime.Now;

        [ObservableProperty]
        private ObservableCollection<Todo> todos;

        [RelayCommand]
        public async Task CaricaTodosAsync()
        {
            var todoList = await _todoService.GetTodosOfUser();
            Todos.Clear();
            foreach (var todoItem in todoList)
            {
                Todos.Add(todoItem);
            }
        }

        [RelayCommand]
        public async Task AddNewTodo()
        {
            var newTodo = new Todo
            {
                Id = 0,
                Title = this.Title,
                Description = this.Description,
                Completed = false,
                StartDate = this.StartDate.UtcDateTime,
                DueDate = this.DueDate.UtcDateTime,
                UserId = SessionService.CurrentUser.Id
            };
            var savedTodo = await _todoService.AddTodo(newTodo);

            if (savedTodo != null)
            {
                Todos.Add(savedTodo); // Aggiorna UI
                await DialogService.ShowAsync("Insert executed", $"Task {Title} is in DB!");
            }
            else
            {
                await DialogService.ShowAsync("Error in insertion", "Something went wrong.");
            }
        }

        [RelayCommand]
        public async Task DeleteTodo()
        {
            var todo = SelectedTodo;

            if (todo == null) return;
            bool isDeleted = await _todoService.DeleteTodo(todo.Id);
            if (isDeleted)
            {
                Todos.Remove(todo); // Aggiorna UI
                await DialogService.ShowAsync("Delete executed", $"Task {todo.Title} deleted from DB!");
            }
            else
            {
                await DialogService.ShowAsync("Error in deletion", "Something went wrong.");
            }
        }
    }
}