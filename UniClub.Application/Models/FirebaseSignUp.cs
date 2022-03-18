namespace UniClub.Application.Models
{
    public class FirebaseSignUp
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool ReturnSecureToken { get; set; } = true;

        public FirebaseSignUp(string email, string password, bool returnSecureToken = true)
        {
            Email = email;
            Password = password;
            ReturnSecureToken = returnSecureToken;
        }
    }
}
