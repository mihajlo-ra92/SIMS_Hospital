// File:    CreatePatientDTO.cs
// Author:  stani
// Created: Sunday, 3 April 2022 19:12:47
// Purpose: Definition of Class CreatePatientDTO

using Model;
using System;

namespace Dto
{
    public class CreatePatientDTO : CreateUserDTO
    {
        public bool IsGuest { get; set; }

    }
}