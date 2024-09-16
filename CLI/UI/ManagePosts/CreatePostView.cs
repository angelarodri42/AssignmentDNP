using Entities;
using RepositoryContracts;

namespace CLI.UI.ManagePosts;

public class CreatePostView
{
    private readonly IPostRepository _postRepository;

    public CreatePostView(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task CreatePost()
    {
        Console.WriteLine("Enter Post Title: ");
        string title = Console.ReadLine();
        
        Console.WriteLine("Enter Post Body: ");
        string body = Console.ReadLine();
        
        Console.WriteLine("Who wrote it?: ");
        int userId = int.Parse(Console.ReadLine());

        Post post = new Post();
        post.Title = title;
        post.Body = body;
        post.UserId = userId;
        
        post= await _postRepository.AddAsync(post);
        Console.WriteLine($"Post with id {post.Id} has been created!");
        Console.WriteLine();
    }
}