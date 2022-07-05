// File:    CreateDoctorDTO.cs
// Author:  stani
// Created: Tuesday, 5 April 2022 13:58:50
// Purpose: Definition of Class CreateDoctorDTO

using Model;
using System;
using System.Collections.Generic;

namespace Dto
{
    public class CreateDoctorDTO : CreateUserDTO
    {
        public decimal Salary { get; set; }
    }
}