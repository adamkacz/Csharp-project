using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class LoginException:Exception
    {
        public LoginException(string msg):base(msg)
        {
        }
    }
}
