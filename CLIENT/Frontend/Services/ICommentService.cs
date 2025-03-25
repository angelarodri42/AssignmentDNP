using ApiContracts.DTOs;
using Entities;

namespace Frontend.Services;

public interface ICommentService
{
    public Task<Comment> Create(CreateCommentDTO dto);
    public Task<Comment> Update(int commentId, UpdatePostDTO dto);
    public Task<Comment> GetSingle(int commentId);
    public Task<List<CommentDTO>> GetMany(GetManyCommentsDTO? dto);
    public Task Delete(int commentId);
}