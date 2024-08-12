using Domains.UserClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerInterfaces
{
    public interface ILoginService
    {
        public User? Login(string identifier, string password);
    }
}
