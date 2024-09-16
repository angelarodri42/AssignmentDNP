using Entities;
using RepositoryContracts;

namespace CLI.UI.ManageUsers;

public class CreateUserView
{
    private readonly IUserRepository _userRepository;

    public CreateUserView(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task AddNewUserAsync()
    {
        Console.WriteLine("Enter username: ");
        string username = Console.ReadLine();

        Console.WriteLine("Enter password: ");
        string password = Console.ReadLine();

        User user = new User();
        user.UserName = username;
        user.Password = password;

        user = await _userRepository.AddAsync(user);
        Console.WriteLine($"User with id {user.Id} has been created!");
        Console.WriteLine();
    }
}