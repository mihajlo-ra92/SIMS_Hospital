// File:    ObjectAlreadyExistsException.cs
// Author:  stani
// Created: Friday, 8 April 2022 17:11:58
// Purpose: Definition of Class ObjectAlreadyExistsException

using System;

namespace Exception
{
    public class ObjectAlreadyExistsException : System.Exception
    {
        public ObjectAlreadyExistsException()
        {

        }

        public ObjectAlreadyExistsException(string message) : base(message)
        {

        }

        public ObjectAlreadyExistsException(string message, System.Exception inner) : base(message, inner)
        {

        }
    }
}