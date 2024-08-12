using Domains.ResultClasses;
using Domains.UserClasses;
using SupportingServices.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace SupportingServices.Services
{
    public class PasswordService : IPasswordService
    {
        public bool VerifyPassword(byte[] passwordSalt, byte[] passwordHash, string password)
        {
            if (passwordHash.Length != 64 || passwordSalt.Length != 128)
            {
                throw new InvalidOperationException("Invalid password hash or salt length.");
            }

            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
