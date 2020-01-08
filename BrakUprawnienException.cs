using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class BrakUprawnienException:Exception
    {
        public BrakUprawnienException(string msg):base(msg)
        {

        }
    }
}
