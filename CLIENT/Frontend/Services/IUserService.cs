using ApiContracts.DTOs;
using Entities;

namespace Frontend.Services;

public interface IUserService
{
    public Task<User> Create(CreateUserDTO dto);
    public Task<User> Update(int userId, UpdateUserDTO dto);
    public Task<User> GetSingle(int userId);
    public Task<List<User>> GetAll();
    public Task Delete(int userId);


}