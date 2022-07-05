// File:    NotFoundException.cs
// Author:  stani
// Created: Friday, 8 April 2022 17:10:36
// Purpose: Definition of Class NotFoundException

using System;

namespace Exception
{
    public class NotFoundException : System.Exception
    {
        public NotFoundException()
        {

        }

        public NotFoundException(string message) : base(message)
        {

        }

        public NotFoundException(string message, System.Exception inner) : base(message, inner)
        {

        }
    }
}