using RepositoryContracts;

namespace CLI.UI.ManagePosts;

public class DeletePostView (IPostRepository postRepository)
{
    public async Task DeletePost()
    {
        Console.WriteLine("Which post do you want to delete (id)?");
        int postId = int.Parse(Console.ReadLine());
       
        await postRepository.DeleteAsync(postId);
        Console.WriteLine("Post deleted");

    }
}