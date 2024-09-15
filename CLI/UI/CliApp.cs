
using System.Security.Cryptography;
using CLI.UI.ManagePosts;
using RepositoryContracts;

namespace CLI.UI;

public class CliApp(
    IUserRepository userRepository,
    ICommentRepository commentRepository,
    IPostRepository postRepository)
{

    public async Task StartAsync()
    {
        while (true)
        {
            Console.WriteLine("Enter your choice:");
            Console.WriteLine("1. Add new post");
            Console.WriteLine("2. View posts");
            Console.WriteLine("3. Delete post");
            Console.WriteLine("4. Edit post");
            Console.WriteLine("5. View one post");
            
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                CreatePostView createPostView = new CreatePostView(postRepository);
                await createPostView.CreatePost();
            }

            if (choice == "2")
            {
                ListPostsView listPostsView = new ListPostsView(postRepository);
                await listPostsView.ListPostsAsync();
            }

            if (choice == "3")
            {
                DeletePostView deletePostView = new DeletePostView(postRepository);
                await deletePostView.DeletePost();
            }

            if (choice == "4")
            {
                UpdatePostsView updatePostsView = new UpdatePostsView(postRepository);
                await updatePostsView.UpdatePostsAsync();
            }

            if (choice == "5")
            {
                SinglePostView singlePostView = new SinglePostView(postRepository);
                await singlePostView.GetSinglePostAsync();
            }

        }
        
    }
}