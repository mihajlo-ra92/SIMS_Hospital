// File:    UsernameExistsException.cs
// Author:  stani
// Created: Friday, 8 April 2022 17:11:59
// Purpose: Definition of Class UsernameExistsException

using System;

namespace Exception
{
    public class UsernameExistsException : System.Exception
    {
        public UsernameExistsException()
        {

        }

        public UsernameExistsException(string message) : base(message)
        {

        }

        public UsernameExistsException(string message, System.Exception inner) : base(message, inner)
        {

        }
    }
}