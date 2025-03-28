﻿using Entities;
using RepositoryContracts;

namespace InMemoryRepositories;

public class UserInMemoryRepository: IUserRepository
{
    List<User> users;

    public Task<User> AddAsync(User user)
    {
        user.Id = users.Any()
            ? users.Max(u => u.Id) + 1
            : 1;
        users.Add(user);
        return Task.FromResult(user);
    }

    public Task UpdateAsync(User user)
    {
        User? existingUser = users.SingleOrDefault(u => u.Id == user.Id);
        if (existingUser is null)
        {
            throw new InvalidOperationException(
                $"User with ID {user.Id} does not exist");
            
        }
        users.Remove(existingUser);
        users.Add(user);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        User? userToRemove = users.SingleOrDefault(u => u.Id == id);
        if (userToRemove is null)
        {
            throw new InvalidOperationException(
                $"User with ID '{id}' was not found");
        }

        users.Remove(userToRemove);
        return Task.CompletedTask;
    }
    public Task<User> GetSingleAsync(int id)
    {
        User? user = users.SingleOrDefault(u => u.Id == id);
        if (user is null)
        {
            throw new InvalidOperationException(
                $"User with ID '{id}' was not found");
        }
        return Task.FromResult(user);
        
    }

    public IQueryable<User> GetMany()
    {
        return users.AsQueryable();
    }

    public Task<User> GetUserByUsername(string username)
    {
        User? user = users.SingleOrDefault(u => u.UserName == username);
        if (user is null)
        {
            throw new InvalidOperationException(
                $"User with username '{username}' was not found");
        }
        return Task.FromResult(user);
    }
}