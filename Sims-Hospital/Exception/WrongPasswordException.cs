using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exception
{
    public class WrongPasswordException : System.Exception
    {
        public WrongPasswordException()
        {

        }

        public WrongPasswordException(string message) : base(message)
        {

        }

        public WrongPasswordException(string message, System.Exception inner) : base(message, inner)
        {

        }
    }
}
