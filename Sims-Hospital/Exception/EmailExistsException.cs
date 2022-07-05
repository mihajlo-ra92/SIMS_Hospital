// File:    EmailExistsException.cs
// Author:  stani
// Created: Friday, 8 April 2022 17:11:59
// Purpose: Definition of Class EmailExistsException

using System;

namespace Exception
{
    public class EmailExistsException : System.Exception
    {
        public EmailExistsException()
        {

        }

        public EmailExistsException(string message) : base(message)
        {

        }

        public EmailExistsException(string message, System.Exception inner) : base(message, inner)
        {

        }
    }
}