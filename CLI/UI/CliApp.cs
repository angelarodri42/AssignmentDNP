
using System.Security.Cryptography;
using CLI.UI.ManageComments;
using CLI.UI.ManagePosts;
using CLI.UI.ManageUsers;
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
            Console.WriteLine("2. View ONLY posts");
            Console.WriteLine("3. Delete post");
            Console.WriteLine("4. Edit post");
            Console.WriteLine("5. View one post (with comments)");
            Console.WriteLine("6. Create a comment");
            Console.WriteLine("7. View posts with comments");
            Console.WriteLine("8. Delete a comment");
            Console.WriteLine("9. Edit a comment");
            Console.WriteLine("10. View a single comment (no post)");
            Console.WriteLine("11. Create a new user");
            Console.WriteLine("12. List all users");
            Console.WriteLine("13. Delete a user");
            Console.WriteLine("14. Edit a user");
            Console.WriteLine("15. View single user");
            
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
                SinglePostView singlePostView = new SinglePostView(postRepository, commentRepository);
                await singlePostView.GetSinglePostAsync();
            }

            if (choice == "6")
            {
                CreateCommentView addCommentView = new CreateCommentView(commentRepository);
                await addCommentView.CreateComment();
            }

            if (choice == "7")
            {
                ListCommentsView listCommentsView = new ListCommentsView(commentRepository, postRepository);
                await listCommentsView.ListCommentsAsync();
            }

            if (choice == "8")
            {
                DeleteCommentView deleteCommentView = new DeleteCommentView(commentRepository);
                await deleteCommentView.DeleteComment();
            }

            if (choice == "9")
            {
                ManageCommentsView manageCommentsView = new ManageCommentsView(commentRepository);
                await manageCommentsView.ManageCommentsAsync();
            }

            if (choice == "10")
            {
                SingleCommentView singleCommentView = new SingleCommentView(commentRepository);
                await singleCommentView.GetSingleCommentAsync();
            }

            if (choice == "11")
            {
                CreateUserView createUserView = new CreateUserView(userRepository);
                await createUserView.AddNewUserAsync();
            }

            if (choice == "12")
            {
                ListUsersView listUsersView = new ListUsersView(userRepository);
                await listUsersView.ListUsersAsync();
            }

            if (choice == "13")
            {
                DeleteUserView deleteUserView = new DeleteUserView(userRepository);
                await deleteUserView.DeleteUser();
            }

            if (choice == "14")
            {
                ManageUsersView manageUsersView = new ManageUsersView(userRepository);
                await manageUsersView.ManageUsersAsync();
            }

            if (choice == "15")
            {
                SingleCommentView singleCommentView = new SingleCommentView(commentRepository);
                await singleCommentView.GetSingleCommentAsync();
            }
            
            


        }
        
    }
}