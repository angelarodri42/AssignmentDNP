using System.ComponentModel.DataAnnotations;

namespace ApiContracts.DTOs;

public class CreateUserDTO
{
    [Required]
    public string username { get; set; }
    
    [Required]
    public string password { get; set; }
}