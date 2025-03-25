using EfcRepositories.Exceptions;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RepositoryContracts;

namespace EfcRepositories;

public class EfcUserRepository : IUserRepository
{
    private readonly AppContext _context;

    public EfcUserRepository(AppContext context)
    {
        this._context = context;
    }
    public async Task<User> AddAsync(User user)
    {
        EntityEntry<User> entry = await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return entry.Entity;
    }

    public async Task UpdateAsync(User user)
    {
        if (!(await _context.Users.AnyAsync(u => u.Id == user.Id)))
        {
            throw new NotFoundException($"User with id {user.Id} not found");
        }
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        User? existing = await _context.Users.SingleOrDefaultAsync(u => u.Id == id);
        if (existing == null)
        {
            throw new NotFoundException($"User with id {id} not found");
        }
        _context.Users.Remove(existing);
        await _context.SaveChangesAsync();
    }

    public async Task<User> GetSingleAsync(int id)
    {
        User? user = await _context.Users.SingleOrDefaultAsync(u => u.Id == id);
        if (user == null)
        {
            throw new NotFoundException($"User with id {id} not found");
        }
        return user;
    }

    public IQueryable<User> GetMany()
    {
        return _context.Users.AsQueryable();
    }

    public Task<User> GetUserByUsername(string username)
    {
        User? user = _context.Users.SingleOrDefault(u => u.UserName == username);
        if (user == null)
        {
            throw new NotFoundException($"User with username {username} not found");
        }
        return Task.FromResult(user);
    }
}