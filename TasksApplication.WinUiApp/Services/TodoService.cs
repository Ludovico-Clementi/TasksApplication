using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TasksApplication.WinUiAPP.Services;
using TasksApplication.DataModels.Models;

namespace TasksApplication.WinUiAPP.Services
{
    public class TodoService
    {
        private readonly HttpClient _httpClient;

        public TodoService(string baseUrl)
        {
            var handler = new HttpClientHandler
            {
                // Permette certificati self-signed in dev (solo sviluppo!)
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };

            _httpClient = new HttpClient(handler)
            {
                BaseAddress = new System.Uri(baseUrl)
            };
        }

        // GET /api/Todo/{userId}
        public async Task<List<Todo>> GetTodosOfUser()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Todo>>($"api/Todo/{SessionService.CurrentUser.Id}") ?? new List<Todo>();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Errore API: {ex.Message}");
                return new List<Todo>();
            }
        }

        // POST /api/Todo
        public async Task<Todo?> AddTodo(Todo todo)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Todo", todo);
            if (response.IsSuccessStatusCode)
            {
                var savedTodo = await response.Content.ReadFromJsonAsync<Todo>();
                return savedTodo;
            }
            return null;
        }

        // DELETE /api/Todo/{id}
        public async Task<bool> DeleteTodo(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Todo/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
