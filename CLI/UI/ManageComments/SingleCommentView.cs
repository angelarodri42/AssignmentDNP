using Entities;
using RepositoryContracts;

namespace CLI.UI.ManageComments;

public class SingleCommentView (ICommentRepository commentRepository)
{
    public async Task GetSingleCommentAsync()
    {
        Console.WriteLine("Which comment do you want to view(id)?");
        int id = int.Parse(Console.ReadLine());
        Comment comment = await commentRepository.GetSingleAsync(id);

        Console.WriteLine("The id of the comment:" + comment.Id);
        Console.WriteLine("The content of the comment:" + comment.Body);
        Console.WriteLine("The id of the user that wrote the comment:" + comment.UserId);
        Console.WriteLine();
    }
}