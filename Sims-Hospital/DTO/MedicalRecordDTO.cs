// File:    MedicalRecordDTO.cs
// Author:  stani
// Created: Tuesday, 5 April 2022 13:58:50
// Purpose: Definition of Class MedicalRecordDTO

using Model;
using System;
using System.Collections.Generic;

namespace Dto
{
    public class MedicalRecordDTO : GuestMedicalRecordDTO
    {
        public string ParentName { get; set; }
        public Address Address { get; set; }
    }
}