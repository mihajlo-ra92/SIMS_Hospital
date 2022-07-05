// File:    CreateAppointmentPatientDTO.cs
// Author:  stani
// Created: Friday, 8 April 2022 21:25:31
// Purpose: Definition of Class CreateAppointmentPatientDTO

using Model;
using System;

namespace Dto
{
    public class CreateAppointmentPatientDTO
    {
        public DateTime StartTime { get; set; }
        public Doctor Doctor { get; set; }
        public string Priority { get; set; }
        public Model.Patient Patient { get; set; }

    }
}