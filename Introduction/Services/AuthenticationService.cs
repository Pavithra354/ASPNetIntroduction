namespace Introduction.Services
{
    public class AuthenticationService : IAuthenticationService
    {

        private static readonly string myToken = "madan!12346711@#@@@@@#$%TGFFDERRRavafas"; 
        public string GenerateToken(string userName, string role = "Customer")
        {
            return myToken;
        }

        public string ValidateToken(string token)
        {
            if (token.Contains("madan"))
            {
                return "Valid";
            }
            else
            {
                return "Invalid";
            }
        }
    }
}
