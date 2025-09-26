using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TasksApplication.DataModels.Models;

namespace TasksApplication.Core.Services;

public class UserService
{
    private readonly HttpClient _httpClient;

    public UserService(string baseUrl)
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

    public async Task<List<User>> GetAllUsers()
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

    public async Task<bool> RegisterUser(User user)
    {
        var response = await _httpClient.PostAsJsonAsync("api/User/register", user);
        return response.IsSuccessStatusCode;
    }

    public async Task<(bool Success, int NewId)> CheckLoginValidity(User user)
    {
        var allUsers = await GetAllUsers();
        var result = allUsers.Any(u => u.Name == user.Name && u.Password == user.Password);
        var id = result ? allUsers.First(u => u.Name == user.Name && u.Password == user.Password).Id : -1;
        return (result, id);
    }

    public async Task<bool> DeleteUser(int userId)
    {
        var response = await _httpClient.DeleteAsync($"api/User/{userId}");
        return response.IsSuccessStatusCode;
    }
}
