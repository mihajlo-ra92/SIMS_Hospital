// File:    UserAlreadyLoggedIn.cs
// Author:  stani
// Created: Sunday, 17 April 2022 23:27:25
// Purpose: Definition of Class UserAlreadyLoggedIn

using System;

namespace Exception
{
    public class UserAlreadyLoggedIn : System.Exception
    {
        public UserAlreadyLoggedIn()
        {

        }

        public UserAlreadyLoggedIn(string message) : base(message)
        {

        }

        public UserAlreadyLoggedIn(string message, System.Exception inner) : base(message, inner)
        {

        }
    }
}
