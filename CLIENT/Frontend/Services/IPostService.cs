using ApiContracts.DTOs;
using Entities;

namespace Frontend.Services;

public interface IPostService
{
    public Task<Post> Create(CreatePostDTO dto);
    public Task<Post> Update(int postId, UpdatePostDTO dto);
    public Task<Post> GetSingle(int postId);
    public Task<List<PostDTO>> GetMany(GetManyPostsDTO? dto);
    public Task Delete(int postId);
}