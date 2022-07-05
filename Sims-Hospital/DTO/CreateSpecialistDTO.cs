// File:    CreateSpecialistDTO.cs
// Author:  stani
// Created: Tuesday, 5 April 2022 13:58:50
// Purpose: Definition of Class CreateSpecialistDTO

using Model;
using System;
using System.Collections.Generic;

namespace Dto
{
    public class CreateSpecialistDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Specialization { get; set; }
    }
}