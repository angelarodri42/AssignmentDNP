using EfcRepositories.Exceptions;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RepositoryContracts;

namespace EfcRepositories;

public class EfcCommentRepository : ICommentRepository
{
    private readonly AppContext _context;
    
    public EfcCommentRepository(AppContext context)
    {
        this._context = context;
    }
    public async Task<Comment> AddAsync(Comment comment)
    {
        EntityEntry<Comment> entry = _context.Comments.Add(comment);
        await _context.SaveChangesAsync();
        return entry.Entity;
    }

    public async Task UpdateAsync(Comment comment)
    {
        if (!(await _context.Comments.AnyAsync(c => c.Id == comment.Id)))
        {
            throw new NotFoundException($"Comment with id {comment.Id} not found");
        }
        _context.Comments.Update(comment);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        Comment? existing = await _context.Comments.SingleOrDefaultAsync(c => c.Id == id);
        if (existing == null)
        {
            throw new NotFoundException($"Comment with id {id} not found");
        }
        _context.Comments.Remove(existing);
        await _context.SaveChangesAsync();
    }
    

    public async Task<Comment> GetSingleAsync(int id)
    {
        Comment? comment = _context.Comments.SingleOrDefault(c => c.Id == id);
        if (comment == null)
        {
            throw new NotFoundException($"Comment with id {id} not found");
        }

        return comment;

    }

    public IQueryable<Comment> GetMany()
    {
        return _context.Comments.AsQueryable();
    }
}