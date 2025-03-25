﻿namespace Entities;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public int UserId { get; set; }
    
    public Post(string title, string body, int userId)
    {
        this.Title = title;
        this.Body = body;
        this.UserId = userId;
    }
    public Post(){}
    
    public User User { get; set; }
    public List<Comment> Comments { get; set; }
    
    
}