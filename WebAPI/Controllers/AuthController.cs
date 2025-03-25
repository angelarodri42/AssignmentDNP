using ApiContracts.DTOs;
using Entities;
using Microsoft.AspNetCore.Mvc;
using RepositoryContracts;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController: ControllerBase
{
    private readonly IUserRepository _userRepository;
    
    public AuthController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDTO dto)
    {
        User? user = await _userRepository.GetUserByUsername(dto.username);
        if (user == null)
        {
            return Unauthorized();
        }

        if (user.Password != dto.password)
        {
            return Unauthorized();
        }

        return Ok(new UserDTO(){Id = user.Id, UserName = user.UserName});
    }
    
}