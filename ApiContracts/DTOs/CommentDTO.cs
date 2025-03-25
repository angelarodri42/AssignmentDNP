namespace ApiContracts.DTOs;

public class CommentDTO
{
    public int Id { get; set; }
    public string Body { get; set; }
    public UserDTO userDto { get; set; }
    public int PostId { get; set; }
}