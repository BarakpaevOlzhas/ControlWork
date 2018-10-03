using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWork
{
    class Accounts
    {
        public string Name { get; set; }
        
        public string Mail { set; get; }

        public string Phone { set; get; }

        public string Password { set; get; }

        public void FastFillingIn(string name, string password, string mail, string phone)
        {
            Name = name;

            Password = password;

            Mail = mail;

            Phone = phone;

        }
    }
}
