using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWork
{
    public interface Register
    {
        bool LogIn(string name, string password);

        string SingUp(string name, string password, string mail, string phone);
    }
}
