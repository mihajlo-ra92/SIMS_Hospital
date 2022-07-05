// File:    EditSpecialistDTO.cs
// Author:  stani
// Created: Tuesday, 5 April 2022 13:58:50
// Purpose: Definition of Class EditSpecialistDTO

using Model;
using System;
using System.Collections.Generic;

namespace Dto
{
    public class EditSpecialistDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Specialization { get; set; }
    }
}