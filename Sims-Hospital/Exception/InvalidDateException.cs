// File:    InvalidDateException.cs
// Author:  stani
// Created: Friday, 8 April 2022 17:10:38
// Purpose: Definition of Class InvalidDateException

using System;

namespace Exception
{
    public class InvalidDateException : System.Exception
    {
        public InvalidDateException()
        {

        }

        public InvalidDateException(string message) : base(message)
        {

        }

        public InvalidDateException(string message, System.Exception inner) : base(message, inner)
        {

        }
    }
}