using Domains.LoginClasses.LoginInputs;
using Domains.UserClasses;

namespace LogicLayer.LoginClasses.LoginStrategies
{
    public interface ILoginStrategy
    {
        public User? Login(LoginInput loginInput);
    }
}
