using ApiContracts.DTOs;
using Entities;
using Microsoft.AspNetCore.Mvc;
using RepositoryContracts;

namespace WebAPI.Controllers;

[Route("[controller]")]
public class CommentsController : ControllerBase
{
    private readonly ICommentRepository _commentRepository;
    public CommentsController(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCommentDTO dto)
    {
        Comment comment = new Comment
        {
            PostId = dto.postId,
            Body = dto.body,
            UserId= dto.userId
        };
        comment= await _commentRepository.AddAsync(comment);
        return Ok(comment);
    }

    [HttpPut("{commentid}")]
    public async Task<IActionResult> Update(int commentId, [FromBody] UpdatePostDTO dto)
    {
        Comment commentToUpdate = await _commentRepository.GetSingleAsync(commentId);
        commentToUpdate.Body = dto.body ?? commentToUpdate.Body;
        
        
        await _commentRepository.UpdateAsync(commentToUpdate);
        return Ok(commentToUpdate);
    }
    
    [HttpGet("{commentId}")]
    public async Task<IActionResult> GetSingle(int commentId)
    {
        Comment comment = await _commentRepository.GetSingleAsync(commentId);
        return Ok(comment);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        IQueryable<Comment> comments = _commentRepository.GetMany();
        return Ok(comments);
    }

    [HttpDelete("{commentId}")]
    public async Task<IActionResult> Delete(int commentId)
    {
        await _commentRepository.DeleteAsync(commentId);
        return Ok();
    }
}