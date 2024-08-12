namespace Domains.LoginClasses.LoginInputs
{
    public class PasswordInput : LoginInput
    {
        public PasswordInput(string identifier, string password) : base(identifier)
        {
            Password = password;
        }

        public string Password { get; }


    }
}
