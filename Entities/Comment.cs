﻿namespace Entities;

public class Comment
{
    public int Id { get; set; }
    public string Body { get; set; }
    public int UserId { get; set; }
    public int PostId { get; set; }
    
    public Comment(string body, int userId, int postId)
    {
        this.Body = body;
        this.UserId = userId;
        this.PostId = postId;
    }
    public Comment(){}
    
    public User User { get; set; }
    public Post Post { get; set; }
    
}