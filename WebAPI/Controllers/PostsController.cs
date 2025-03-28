﻿using ApiContracts.DTOs;
using Entities;
using Microsoft.AspNetCore.Mvc;
using RepositoryContracts;

namespace WebAPI.Controllers;
[Route("[controller]")]
public class PostsController : ControllerBase

{
    private readonly IPostRepository _postRepository;
    private readonly IUserRepository _userRepository;
    public PostsController(IPostRepository postRepository, IUserRepository userRepository)
    {
        _postRepository = postRepository;
        _userRepository = userRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePostDTO dto)
    {
        Post post = new Post
        {
            Title = dto.title,
            Body = dto.body,
            UserId= dto.userId
        };
        post= await _postRepository.AddAsync(post);
        return Ok(post);
    }

    [HttpPut("{postid}")]
    public async Task<IActionResult> Update(int postId, [FromBody] UpdatePostDTO dto)
    {
        Post postToUpdate = await _postRepository.GetSingleAsync(postId);
        postToUpdate.Title = dto.title ?? postToUpdate.Title;
        postToUpdate.Body = dto.body ?? postToUpdate.Body;
        
        await _postRepository.UpdateAsync(postToUpdate);
        return Ok(postToUpdate);
    }
    
    [HttpGet("{postId}")]
    public async Task<IActionResult> GetSingle(int postId)
    {
        Post post = await _postRepository.GetSingleAsync(postId);
        return Ok(post);
    }

    [HttpGet]
    public async Task<IActionResult> GetMany(GetManyPostsDTO? dto)
    {
        IQueryable<Post> posts = _postRepository.GetMany();

        if (dto != null)
        {
            if (dto.title != null)
            {
                posts= posts.Where(p=>p.Title.Contains(dto.title));
                
            }

            if (dto.body != null)
            {
                posts = posts.Where(p => p.Body.Contains(dto.body));
            }

            if (dto.userId != null)
            {
                posts = posts.Where(p => p.UserId == dto.userId);
            }
        }
        List<PostDTO> postDtos = new List<PostDTO>();
        foreach (Post post in posts)
        {
            var user = await _userRepository.GetSingleAsync(post.UserId);

            postDtos.Add(new PostDTO
            {
                Id = post.Id,
                Title = post.Title,
                Body = post.Body,
                userDto = new UserDTO
                {
                    Id = user.Id,
                    UserName = user.UserName
                }
            });
        }
        
        
        return Ok(postDtos);
    }

    [HttpDelete("{postId}")]
    public async Task<IActionResult> Delete(int postId)
    {
        await _postRepository.DeleteAsync(postId);
        return Ok();
    }
}
