using Domains.ResultClasses;
using Enums;
using System.Security.Cryptography;
using System.Text;

namespace Domains.UserClasses
{
    public class User
    {
        private Guid _id;
        private string _firstName;
        private string _lastName;
        private string _userName;
        private string _email;
        private byte[] _passwordHash;
        private byte[] _passwordSalt;
        private UserRole _userRole;
        private bool _deactivated;
        private bool _ban;

        public Guid Id { get => _id; }
        public string FirstName { get => _firstName; }
        public string LastName { get => _lastName; }
        public string UserName { get => _userName; }
        public string Email { get => _email; }
        public byte[] PasswordHash { get => _passwordHash; }
        public byte[] PasswordSalt { get => _passwordSalt; }
        public UserRole UserRole { get => _userRole; }
        public bool Deactivated { get => _deactivated; }
        public bool Ban { get => _ban; }

        public User(string firstName, string lastName, string userName, string email, string password, UserRole userRole)
        {
            _id = Guid.NewGuid();
            _firstName = firstName;
            _lastName = lastName;
            _userName = userName;
            _email = email;
            SetPassword(password);
            _userRole = userRole;
            _deactivated = false;
            _ban = false;
        }

        public User(Guid id, string firstName, string lastName, string userName, string email, byte[] passwordHash, byte[] passwordSalt, UserRole userRole, bool deactivated, bool ban)
        {
            _id = id;
            _firstName = firstName;
            _lastName = lastName;
            _userName = userName;
            _email = email;
            _passwordHash = passwordHash;
            _passwordSalt = passwordSalt;
            _userRole = userRole;
            _deactivated = deactivated;
            _ban = ban;
        }

        //public void UpdateUser(string username, string email, string password, string firstname, string lastname, UserRole userRole, bool ban, bool deactivated)
        //{
        //    _userName = username;
        //    _email = email;
        //    SetPassword(password);
        //    _firstName = firstname;
        //    _lastName = lastname;
        //    _userRole = userRole;
        //    _deactivated = deactivated;
        //    _ban = ban;
        //}

        public void UpdateUser(string username, string email, string firstname, string lastname, UserRole userRole, bool ban, bool deactivated)
        {
            _userName = username;
            _email = email;
            _firstName = firstname;
            _lastName = lastname;
            _userRole = userRole;
            _deactivated = deactivated;
            _ban = ban;
        }

        public void UpdateDetails(string firstName, string lastName, string userName, string email)
        {
            _firstName = firstName;
            _lastName = lastName;
            _userName = userName;
            _email = email;
        }

        public Result ChangePasswordByItsUser(string oldPassword, string newPassword, Guid userId)
        {
            if (userId == _id)
            {
                if (VerifyPassword(oldPassword))
                {
                    SetPassword(newPassword);
                    return new Result(true, "Password changed");
                }
                else
                {
                    return new Result(false, "Given old password is wrong.");
                }
            }
            else
            {
                return new Result(false, "You are not the user of this account. How did you breach our security dude?");
            }
        }

        public Result ChangePasswordByAdmin(string password, bool userIsAdmin)
        {
            if (userIsAdmin)
            {
                SetPassword(password);
                return new Result(true, "Password changed");
            }
            else
            {
                return new Result(false, "You are not and admin.");
            }
        }

        public bool IsAdmin()
        {
            if (_userRole == UserRole.Admin)
            {
                return true;
            }
            return false;
        }

        public Result BanUser(bool ban)
        {
            if (!ban && _ban)
            {
                return new Result(true, "Note! This user was already BANNAED. If you really want to unban them. Do it manually.");
            }
            _ban = true;
            return new Result(true, "User successfully banned.");
        }

        public Result UnbanUser()
        {
            _ban = false;
            return new Result(true, "User successfully unbanned.");
        }

        public string GetFullName()
        {
            return $"{_firstName} {_lastName}";
        }

        public string GetFullNameWithUserName()
        {
            return $"{_firstName} {_lastName} (@{_userName})";
        }

        public string GetFullNameWithUserNameAndEmail()
        {
            return $"{_firstName} {_lastName} (@{_userName} -- {_email})";
        }

        private byte[] GenerateSalt()
        {
            byte[] salt = new byte[128];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        private void SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password cannot be empty.");
            }

            _passwordSalt = GenerateSalt();

            using (var hmac = new HMACSHA512(_passwordSalt))
            {
                _passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public bool VerifyPassword(string password)
        {
            if (_passwordHash.Length != 64 || _passwordSalt.Length != 128)
            {
                throw new InvalidOperationException("Invalid password hash or salt length.");
            }

            using (var hmac = new HMACSHA512(_passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                bool passwordsMatch = computedHash.Length == _passwordHash.Length;
                for (int i = 0; i < computedHash.Length && i < _passwordHash.Length; i++)
                {
                    if (computedHash[i] != _passwordHash[i])
                    {
                        passwordsMatch = false;
                    }
                }

                return passwordsMatch;
            }
        }

        public Result ToggleUserBan(bool ban)
        {
            if (_ban && ban)
            {
                return new Result(true, $"{GetFullNameWithUserName()} was already banned.");
            }
            else if (!_ban && ban)
            {
                _ban = ban;
                return new Result(true, $"{GetFullNameWithUserName()} was banned successfully.");
            }
            else if (!_ban && !ban)
            {
                return new Result(true, $"{GetFullNameWithUserName()} was not banned.");
            }
            else if (_ban && !ban)
            {
                _ban = ban;
                return new Result(true, $"{GetFullNameWithUserName()} was unbanned successfully.");
            }
            return new Result(false, "Something went wrong");
        }

        public override string ToString()
        {
            return String.Format($"{_userRole}: {GetFullNameWithUserNameAndEmail()}");
        }
    }
}