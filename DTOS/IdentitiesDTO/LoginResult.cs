namespace DTOS.IdentitiesDTO;
public class LoginResult
{
    public string Id { get; set; } = "";
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
    public DateTime ExpireAt { get; set; }
}
