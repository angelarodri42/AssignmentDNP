using Entities;
using RepositoryContracts;

namespace CLI.UI.ManageComments;

public class ListCommentsView (ICommentRepository commentRepository, IPostRepository postRepository)
{
    public async Task ListCommentsAsync()
    {
        IQueryable<Post> allPosts = postRepository.GetMany();
        
        IQueryable<Comment> comments = commentRepository.GetMany();

        foreach (Post post in allPosts)
        {
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
    
}