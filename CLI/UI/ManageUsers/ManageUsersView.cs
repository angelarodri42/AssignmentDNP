using Entities;
using RepositoryContracts;

namespace CLI.UI.ManageUsers;

public class ManageUsersView(IUserRepository userRepository)
{
    public async Task ManageUsersAsync()
    {
        Console.WriteLine("Which user do you want to modify(id)?");
        int id = int.Parse(Console.ReadLine());

        User user = await userRepository.GetSingleAsync(id);

        Console.WriteLine("What do you want to edit, the username (U) or the password (P)?");
        char choice = char.Parse(Console.ReadLine());
        if (choice == 'U')
        {
            Console.WriteLine("Enter user's new username: ");
            string username = Console.ReadLine();
            user.UserName = username;
        }

        if (choice == 'P')
        {
            Console.WriteLine("Enter user's new password: ");
            string password = Console.ReadLine();
            user.Password = password;
        }

        await userRepository.UpdateAsync(user);
        Console.WriteLine("User Updated");
        Console.WriteLine();
    }
}
