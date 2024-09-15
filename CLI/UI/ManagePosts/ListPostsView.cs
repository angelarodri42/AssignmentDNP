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
            Console.WriteLine(post.Title);
            Console.WriteLine(post.Body);
            Console.WriteLine(post.Id);
        }
    }
}