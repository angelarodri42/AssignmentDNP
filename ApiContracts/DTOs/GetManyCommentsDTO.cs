namespace ApiContracts.DTOs;

public class GetManyCommentsDTO
{
    public string? body { get; set; }
    public int? userId { get; set; }
    public int? postId { get; set; }
}