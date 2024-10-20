using ApiContracts.DTOs;
using Entities;
using Microsoft.AspNetCore.Mvc;
using RepositoryContracts;

namespace WebAPI.Controllers;
[Route("[controller]")]
public class PostsController : ControllerBase

{
    private readonly IPostRepository _postRepository;
    public PostsController(IPostRepository postRepository)
    {
        _postRepository = postRepository;
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
    public async Task<IActionResult> GetAll()
    {
        IQueryable<Post> posts = _postRepository.GetMany();
        return Ok(posts);
    }

    [HttpDelete("{postId}")]
    public async Task<IActionResult> Delete(int postId)
    {
        await _postRepository.DeleteAsync(postId);
        return Ok();
    }
}
