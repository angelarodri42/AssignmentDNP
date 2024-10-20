using System.ComponentModel.DataAnnotations;

namespace ApiContracts.DTOs;

public class CreatePostDTO
{
    [Required]
    public string title { get; set; }
    
    [Required]
    public string body { get; set; }
    
    [Required]
    public int userId { get; set; }
}