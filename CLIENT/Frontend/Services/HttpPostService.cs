using System.Text;
using System.Text.Json;
using ApiContracts.DTOs;
using Entities;

namespace Frontend.Services;

public class HttpPostService : IPostService
{
    private readonly HttpClient _client;
    
    public HttpPostService(HttpClient client)
    {
        _client = client;
    }
    
    public async Task<Post> Create(CreatePostDTO dto)
    {
        var json = JsonSerializer.Serialize(dto);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        
        var response = await _client.PostAsync("/Posts", content);
        
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Error: {response.StatusCode}");
        }
        
        var responseJson = await response.Content.ReadAsStringAsync();
        
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        
        return JsonSerializer.Deserialize<Post>(responseJson, options);
    }

    public async Task<Post> Update(int postId, UpdatePostDTO dto)
    {
        var json = JsonSerializer.Serialize(dto);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        
        var response = await _client.PutAsync($"/Posts/{postId}", content);
        
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Error: {response.StatusCode}");
        }
        var responseJson = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        return JsonSerializer.Deserialize<Post>(responseJson, options);
    }

    public async Task<Post> GetSingle(int postId)
    {
        var response = await _client.GetAsync($"/Posts/{postId}");
        
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Error: {response.StatusCode}");
        }
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        return JsonSerializer.Deserialize<Post>(await response.Content.ReadAsStringAsync(), options);
    }

    public async Task<List<PostDTO>> GetMany(GetManyPostsDTO? dto)
    {
        var response = await _client.GetAsync("/Posts");
        
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Error: {response.StatusCode}");
        }
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        return JsonSerializer.Deserialize<List<PostDTO>>(await response.Content.ReadAsStringAsync(), options);
    }

    public async Task Delete(int postId)
    {
        var content = new StringContent("", Encoding.UTF8, "application/json");
        var response = await _client.DeleteAsync($"/Posts/{postId}");
        
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Error: {response.StatusCode}");
        }
        
    }
}