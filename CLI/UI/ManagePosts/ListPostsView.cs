using Entities;
using RepositoryContracts;

namespace CLI.UI.ManagePosts;

public class ListPostsView(IPostRepository postRepository)
{
    public async Task ListPostsAsync()
    {
        IQueryable<Post> posts = postRepository.GetMany();
        foreach (Post post in posts)
        {
            Console.WriteLine();
            Console.WriteLine("Title:"+ post.Title);
            Console.WriteLine("Body:" + post.Body);
            Console.WriteLine("Post id:" + post.Id);
            Console.WriteLine("Id of the user that wrote the post:" + post.UserId);
            Console.WriteLine();
            
        }
    }
}