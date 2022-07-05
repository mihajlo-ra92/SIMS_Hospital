// File:    CreateUserDTO.cs
// Author:  stani
// Created: Saturday, 16 April 2022 16:49:10
// Purpose: Definition of Class CreateUserDTO

using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class CreateUserDTO
    {
        public int Id { get; set; } = -1;
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string Role { get; set; }
    }
}
