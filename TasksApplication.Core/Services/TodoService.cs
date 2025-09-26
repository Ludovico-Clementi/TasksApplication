using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TasksApplication.DataModels.Models;

namespace TasksApplication.Core.Services;

public class TodoService
{
    private readonly HttpClient _httpClient;

    public TodoService(string baseUrl)
    {
        var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
        };
        _httpClient = new HttpClient(handler)
        {
            BaseAddress = new Uri(baseUrl)
        };
    }

    public async Task<List<Todo>> GetTodosOfUser()
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<List<Todo>>($"api/Todo/{SessionService.CurrentUser.Id}")
                   ?? new List<Todo>();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Errore API: {ex.Message}");
            return new List<Todo>();
        }
    }

    public async Task<Todo?> AddTodo(Todo todo)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Todo", todo);
        if (response.IsSuccessStatusCode)
            return await response.Content.ReadFromJsonAsync<Todo>();
        return null;
    }

    public async Task<bool> DeleteTodo(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/Todo/{id}");
        return response.IsSuccessStatusCode;
    }
}
