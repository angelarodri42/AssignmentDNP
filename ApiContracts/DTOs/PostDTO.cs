namespace ApiContracts.DTOs;

public class PostDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public UserDTO userDto { get; set; }
}