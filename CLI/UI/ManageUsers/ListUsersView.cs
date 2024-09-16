using Entities;
using RepositoryContracts;

namespace CLI.UI.ManageUsers;

public class ListUsersView (IUserRepository userRepository)
{
    public async Task ListUsersAsync()
    {
        IQueryable<User> users = userRepository.GetMany();
        foreach (User user in users)
        {
            Console.WriteLine();
            Console.WriteLine("Username:"+ user.UserName);
            Console.WriteLine("Password (cover your eyes for this line):" + user.Password);
            Console.WriteLine("Id of the user:" + user.Id);
            Console.WriteLine();
        }
    }
}