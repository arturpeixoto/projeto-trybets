namespace TryBets.Users.DTO;

public class AuthDTORequest
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
}

public class AuthDTOResponse
{
    public string? Token { get; set; }
}