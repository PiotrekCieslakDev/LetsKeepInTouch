using Domains.ResultClasses;
using Domains.UserClasses;
using System.Security.Cryptography;
using System.Text;

namespace SupportingServices.Interfaces
{
    public interface IPasswordService
    {
        public bool VerifyPassword(byte[] passwordSalt, byte[]passwordHash, string password);
    }
}
