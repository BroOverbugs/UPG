namespace DTOS.IdentitiesDTO;

public class RegisterUser : LoginUser
{
    public string FirstName { get; set; } = string.Empty;
    public string? LastName { get; set; } = string.Empty;
}