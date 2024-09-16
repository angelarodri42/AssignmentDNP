using Entities;
using RepositoryContracts;

namespace CLI.UI.ManagePosts;

public class SinglePostView(IPostRepository postRepository, ICommentRepository commentRepository)
{
    public async Task GetSinglePostAsync()
    {
        
        Console.WriteLine("Which post do you want to view(id)?");
        int id = int.Parse(Console.ReadLine());
        Post post = await postRepository.GetSingleAsync(id);
        IQueryable<Comment> comments = commentRepository.GetMany();

        Console.WriteLine();
        Console.WriteLine("POST");
        Console.WriteLine("Title:"+ post.Title);
        Console.WriteLine("Body:" + post.Body);
        Console.WriteLine("Post id:" + post.Id);
        Console.WriteLine("Id of the user that wrote the post:" + post.UserId);
        Console.WriteLine("COMMENTS");

        List<Comment> postComments = comments.Where(c => c.PostId == post.Id).ToList();
        
        foreach (Comment comment in postComments)
        {

            Console.WriteLine("The id of the comment:" + comment.Id);
            Console.WriteLine("The content of the comment:" + comment.Body);
            Console.WriteLine("The id of the user that wrote the comment:" + comment.UserId);
            Console.WriteLine();
        }

    }
}
