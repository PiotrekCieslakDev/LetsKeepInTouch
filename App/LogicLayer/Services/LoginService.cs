using DataAccessLayerInterfaces;
using Domains.UserClasses;
using Enums;
using LogicLayer.LoginClasses.LoginStrategies;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Services
{
    public class LoginService : ILoginService
    {
        IUserRepository _userRepository;

        ILoginStrategy _loginMethod;

        public LoginService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public LoginService(IUserRepository userRepository, ILoginStrategy loginMethod)
        {
            _userRepository = userRepository;
        }

        public User? Login(string identifier, string password)
        {
            identifier = identifier.ToLower();
            User? user = _userRepository.GetUserByIdentifier(identifier);
            if (user != null && user.VerifyPassword(password))
            {
                if (!user.Ban && !user.Deactivated)
                {
                    return user;
                }
            }

            return null;
        }




        //public User? Login(string identifier, string password)
        //{
        //    identifier = identifier.ToLower();
        //    User? user = _userRepository.GetUserByIdentifier(identifier);
        //    if (user != null && user.VerifyPassword(password))
        //    {
        //        if (!user.Ban && !user.Deactivated)
        //        {
        //            return user;
        //        }
        //    }

        //    return null;
        //}
    }
}
