using Entities;
using RepositoryContracts;

namespace CLI.UI.ManageComments;

public class ManageCommentsView(ICommentRepository commentRepository)
{
    public async Task ManageCommentsAsync()
    {
        Console.WriteLine("Which comment do you want to modify(id)?");
        int id = int.Parse(Console.ReadLine());

        Comment comment = await commentRepository.GetSingleAsync(id);
        Console.WriteLine("Enter new content of the comment: ");
        string body = Console.ReadLine();
        comment.Body = body;
        await commentRepository.UpdateAsync(comment);
        Console.WriteLine("Comment Updated");
        Console.WriteLine();
    }
}
