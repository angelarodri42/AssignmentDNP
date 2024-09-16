using Entities;
using RepositoryContracts;

namespace CLI.UI.ManageComments;

public class CreateCommentView
{
    private readonly ICommentRepository _commentRepository;

    public CreateCommentView(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }
    public async Task CreateComment()
    {
        Console.WriteLine("Enter comment content: ");
        string body = Console.ReadLine();
        
        Console.WriteLine("To what post do you want to create a comment?(id): ");
        int postId = int.Parse(Console.ReadLine());
        
        Console.WriteLine("Who wrote it?: ");
        int userId = int.Parse(Console.ReadLine());

        Comment comment = new Comment();
        comment.Body = body;
        comment.UserId = userId;
        comment.PostId = postId;
        
        comment= await _commentRepository.AddAsync(comment);
        Console.WriteLine($"Comment with id {comment.Id} has been created!");
    }
}