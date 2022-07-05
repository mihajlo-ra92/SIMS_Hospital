// File:    GuestMedicalRecordDTO.cs
// Author:  stani
// Created: Tuesday, 5 April 2022 13:58:51
// Purpose: Definition of Class GuestMedicalRecordDTO

using DTO;
using Model;
using System;
using System.Collections.Generic;

namespace Dto
{
    public class GuestMedicalRecordDTO
    {
        public string Umcn { get; set; }
        public PatientAllergies Allergies { get; set; }
        public BloodType BloodType { get; set; }
        public Patient Patient { get; set; }

    }
}