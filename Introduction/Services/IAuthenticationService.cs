namespace Introduction.Services
{
    public interface IAuthenticationService
    {
        string GenerateToken(string userName, string role = "Customer");

        string ValidateToken(string token);
    }
}