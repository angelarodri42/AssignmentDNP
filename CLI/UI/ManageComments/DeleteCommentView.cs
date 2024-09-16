using RepositoryContracts;

namespace CLI.UI.ManageComments;

public class DeleteCommentView(ICommentRepository commentRepository)
{
    public async Task DeleteComment()
    {
        Console.WriteLine("Which comment do you want to delete (id of the comment)?");
        int commentId = int.Parse(Console.ReadLine());

        await commentRepository.DeleteAsync(commentId);
        Console.WriteLine("Comment deleted");
        Console.WriteLine();

    }
}

