using RepositoryContracts;

namespace CLI.UI.ManageUsers;

public class DeleteUserView(IUserRepository userRepository)
{
    public async Task DeleteUser()
    {
        Console.WriteLine("Which user do you want to delete (id)?");
        int userId = int.Parse(Console.ReadLine());
       
        await userRepository.DeleteAsync(userId);
        Console.WriteLine("User deleted");
        Console.WriteLine();

    }
}