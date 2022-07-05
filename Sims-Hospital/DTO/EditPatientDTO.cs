// File:    EditPatientDTO.cs
// Author:  stani
// Created: Friday, 8 April 2022 17:03:58
// Purpose: Definition of Class EditPatientDTO

using Model;
using System;

namespace Dto
{
    public class EditPatientDTO : EditUserDTO
    {
        public bool IsGuest { get; set; }

    }
}