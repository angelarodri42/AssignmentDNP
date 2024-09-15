using Entities;
using RepositoryContracts;

namespace CLI.UI.ManagePosts;

public class SinglePostView(IPostRepository postRepository)
{
    public async Task GetSinglePostAsync()
    {
        Console.WriteLine("Which post do you want to get(id)?");
        int id = int.Parse(Console.ReadLine());
        Post post = await postRepository.GetSingleAsync(id);

        Console.WriteLine(post.Title);
        Console.WriteLine(post.Body);
        Console.WriteLine(post.Id);

    }
}
