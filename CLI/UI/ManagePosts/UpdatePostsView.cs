using Entities;
using RepositoryContracts;

namespace CLI.UI.ManagePosts;

public class UpdatePostsView (IPostRepository postRepository)
{
    public async Task UpdatePostsAsync()
    {
        Console.WriteLine("Which post do you want to modify(id)?");
        int id = int.Parse(Console.ReadLine());

        Post post = await postRepository.GetSingleAsync(id);
        
        Console.WriteLine("What do you want to edit, the title (T) or the body (B)?");
        char choice = char.Parse(Console.ReadLine());
        if (choice == 'T')
        {
            Console.WriteLine("Enter Post new Title: ");
            string title = Console.ReadLine();
            post.Title = title;
        }

        if (choice == 'B')
        {
            Console.WriteLine("Enter Post new Body: ");
            string body = Console.ReadLine();
            post.Body = body;
        }
        await postRepository.UpdateAsync(post);
        Console.WriteLine("Post Updated");
        
        

        
        
        
        

    }
}