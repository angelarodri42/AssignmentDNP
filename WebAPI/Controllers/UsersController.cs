using ApiContracts.DTOs;
using Entities;
using Microsoft.AspNetCore.Mvc;
using RepositoryContracts;

namespace WebAPI.Controllers;
[Route("[controller]")]
public class UsersController: ControllerBase
{
    private readonly IUserRepository _userRepository;
    public UsersController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserDTO dto)
    {
        User user = new User
        {
            UserName = dto.username,
            Password = dto.password
        };
        user= await _userRepository.AddAsync(user);
        return Ok(user);
    }

    [HttpPut("{userid}")]
    public async Task<IActionResult> Update(int userId, [FromBody] UpdateUserDTO dto)
    {
        User userToUpdate = await _userRepository.GetSingleAsync(userId);
        userToUpdate.UserName = dto.username ?? userToUpdate.UserName;
        userToUpdate.Password = dto.password ?? userToUpdate.Password;
        
        await _userRepository.UpdateAsync(userToUpdate);
        return Ok(userToUpdate);
    }
    
    [HttpGet("{userId}")]
    public async Task<IActionResult> GetSingle(int userId)
    {
        User user = await _userRepository.GetSingleAsync(userId);
        return Ok(user);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        IQueryable<User> users = _userRepository.GetMany();
        return Ok(users);
    }

    [HttpDelete("{userId}")]
    public async Task<IActionResult> Delete(int userId)
    {
        await _userRepository.DeleteAsync(userId);
        return Ok();
    }
}