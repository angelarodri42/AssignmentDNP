using System.Security.Claims;
using System.Text.Json;
using ApiContracts.DTOs;
using Microsoft.AspNetCore.Components.Authorization;

namespace Frontend.Auth;

public class SimpleAuthProvider : AuthenticationStateProvider
{
    private readonly HttpClient httpClient;
    private ClaimsPrincipal currentClaimsPrincipal;

    public SimpleAuthProvider(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task Login(string userName, string password)
    {
        HttpResponseMessage response = await httpClient.PostAsJsonAsync("api/Auth/Login", currentClaimsPrincipal);
        
        string content =await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
        
        UserDTO userDto = JsonSerializer.Deserialize<UserDTO>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, userDto.UserName),
            new Claim(ClaimTypes.NameIdentifier, userDto.Id.ToString())
        };

        ClaimsIdentity identity = new ClaimsIdentity(claims, "apiauth");
        currentClaimsPrincipal = new ClaimsPrincipal(identity);
        
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(currentClaimsPrincipal)));
    }
    
    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        return new Task<AuthenticationState>(currentClaimsPrincipal ?? new());
    }
    
}