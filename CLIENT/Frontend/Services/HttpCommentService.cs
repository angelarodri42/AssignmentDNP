using System.Text;
using System.Text.Json;
using System.Web;
using ApiContracts.DTOs;
using Entities;

namespace Frontend.Services;

public class HttpCommentService(HttpClient client) : ICommentService
{
    public async Task<Comment> Create(CreateCommentDTO dto)
    {
        var json = JsonSerializer.Serialize(dto);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PostAsync("/Comments", content);

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Error: {response.StatusCode}");
        }

        var responseJson = await response.Content.ReadAsStringAsync();

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        return JsonSerializer.Deserialize<Comment>(responseJson, options);
    }

    public async Task<Comment> Update(int commentId, UpdatePostDTO dto)
    {
        var json = JsonSerializer.Serialize(dto);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PutAsync($"/Comments/{commentId}", content);

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Error: {response.StatusCode}");
        }

        var responseJson = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        return JsonSerializer.Deserialize<Comment>(responseJson, options);
    }

    public async Task<Comment> GetSingle(int commentId)
    {
        var response = await client.GetAsync($"/Comments/{commentId}");

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Error: {response.StatusCode}");
        }

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        return JsonSerializer.Deserialize<Comment>(await response.Content.ReadAsStringAsync(), options);
    }

    public async Task<List<CommentDTO>> GetMany(GetManyCommentsDTO? dto)
    {
        var uriBuilder = new UriBuilder
        {
            Path = "/Comments",
            Query = string.Empty
        };
        var query = HttpUtility.ParseQueryString(uriBuilder.Query);

        if (dto != null)
        {
            if (dto.postId.HasValue)
            {
                query["postId"] = dto.postId.Value.ToString();
            }
            if (!string.IsNullOrEmpty(dto.body))
            {
                query["body"] = dto.body;
            }
            if (dto.userId.HasValue)
            {
                query["userId"] = dto.userId.Value.ToString();
            }
        }

        uriBuilder.Query = query.ToString();
        var response = await client.GetAsync(uriBuilder.Path + uriBuilder.Query);


        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Error: {response.StatusCode}");
        }

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        return JsonSerializer.Deserialize<List<CommentDTO>>(await response.Content.ReadAsStringAsync(), options);
    }

    public async Task Delete(int commentId)
    {
        var content = new StringContent(string.Empty, Encoding.UTF8, "application/json");
        var response = await client.DeleteAsync($"/Comments/{commentId}");

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Error: {response.StatusCode}");

        }

    }
}