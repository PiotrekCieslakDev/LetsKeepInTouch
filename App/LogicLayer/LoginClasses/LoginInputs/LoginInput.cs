namespace Domains.LoginClasses.LoginInputs
{
    public class LoginInput
    {
        public string Identifier { get; private set; }

        public LoginInput(string identifier)
        {
            if (identifier == null)
            {
                throw new ArgumentOutOfRangeException(nameof(identifier), "Identifier can't be null");
            }
            Identifier = identifier;
        }
    }
}
