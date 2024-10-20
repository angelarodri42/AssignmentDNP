namespace ApiContracts.DTOs;

public class GetManyPostsDTO
{
    public string? title { get; set; }
    public string? body { get; set; }
    public int? userId { get; set; }
}