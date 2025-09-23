using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TasksApplication.DataModels.Models;

namespace TasksApplication.WinUiAPP.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;

        public UserService(string baseUrl)
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

        // GET /api/User/All
        public async Task<List<User>> GetAllUser()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<User>>("api/User/All") ?? new List<User>();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Errore API: {ex.Message}");
                return new List<User>();
            }
        }

        // POST /api/User/register
        public async Task<bool> RegisterUser(User user)
        {
            var response = await _httpClient.PostAsJsonAsync("api/User/register", user);
            return response.IsSuccessStatusCode;
        }

        // Login Check
        public async Task<(bool Success, int NewId)> CheckLoginValidity(User user)
        {
            var allUsers = await GetAllUser();
            var result = allUsers.Any(u => u.Name == user.Name && u.Password == user.Password);
            var id = result ? allUsers.First(u => u.Name == user.Name && u.Password == user.Password).Id : -1;
            return (result,id);
        }

        // DELETE /api/User/{id}
        public async Task<bool> DeleteUser(int userId)
        {
            // Chiamata DELETE verso l'endpoint
            var response = await _httpClient.DeleteAsync($"api/user/{userId}");

            // Ritorna true se la chiamata ha avuto successo (status 200-299)
            return response.IsSuccessStatusCode;
        }

    }
}
