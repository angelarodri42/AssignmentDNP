using System.Text;
using System.Text.Json;
using ApiContracts.DTOs;
using Entities;

namespace Frontend.Services;

public class HttpUserService (HttpClient client) : IUserService
{
    public async Task<User> Create(CreateUserDTO dto)
    {
        var json = JsonSerializer.Serialize(dto);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PostAsync("/Users", content);

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Error: {response.StatusCode}");
        }

        var responseJson = await response.Content.ReadAsStringAsync();
        
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        
        return JsonSerializer.Deserialize<User>(responseJson, options);
    }

    public async Task<User> Update(int userId, UpdateUserDTO dto)
    {
        var json = JsonSerializer.Serialize(dto);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        
        var response = await client.PutAsync($"/Users/{userId}", content);

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Error: {response.StatusCode}");
        }
        
        var responseJson = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        return JsonSerializer.Deserialize<User>(responseJson, options);
    }

    public async Task<User> GetSingle(int userId)
    {
         var response = await client.GetAsync($"/Users/{userId}");

         if (!response.IsSuccessStatusCode)
         {
             throw new HttpRequestException($"Error: {response.StatusCode}");
         }
         var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
         return JsonSerializer.Deserialize<User>(await response.Content.ReadAsStringAsync(), options);
    }

    public async Task<List<User>> GetAll()
    {
        var response = await client.GetAsync("/Users");

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Error: {response.StatusCode}");
        }
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        return JsonSerializer.Deserialize<List<User>>(await response.Content.ReadAsStringAsync(), options);
    }
    

    public async Task Delete(int userId)
    {
        var content = new StringContent(JsonSerializer.Serialize(userId), Encoding.UTF8, "application/json");
        var response = await client.DeleteAsync($"/Users/{userId}");

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Error: {response.StatusCode}");
        }
        
    }
}