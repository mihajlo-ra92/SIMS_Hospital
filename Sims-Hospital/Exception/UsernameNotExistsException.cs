// File:    UsernameNotExistsException.cs
// Author:  stani
// Created: Friday, 8 April 2022 17:11:59
// Purpose: Definition of Class UsernameNotExistsException

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exception
{
    public class UsernameNotExistsException : System.Exception
    {
        public UsernameNotExistsException()
        {

        }

        public UsernameNotExistsException(string message) : base(message)
        {

        }

        public UsernameNotExistsException(string message, System.Exception inner) : base(message, inner)
        {

        }
    }
}
