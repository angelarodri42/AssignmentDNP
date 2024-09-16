using Entities;
using RepositoryContracts;

namespace CLI.UI.ManageUsers;

public class SingleUserView (IUserRepository userRepository)
{
    public async Task GetSingleUserAsync()
    {
        Console.WriteLine("Which user do you want to view(id)?");
        int id = int.Parse(Console.ReadLine());
        User user = await userRepository.GetSingleAsync(id);

        Console.WriteLine("The id of the user:" + user.Id);
        Console.WriteLine("The username:" + user.UserName);
        Console.WriteLine("The password:" + user.Password);
        Console.WriteLine();
    }
}