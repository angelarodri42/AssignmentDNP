namespace Entities;

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    
    public User(string userName, string password)
    {
        this.UserName = userName;
        this.Password = password;
    }
    public User(){}
    
    public List<Post> Posts { get; set; }
    public List<Comment> Comments { get; set; }
    
}