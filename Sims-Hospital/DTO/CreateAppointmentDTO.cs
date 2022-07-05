// File:    CreateAppointmentDTO.cs
// Author:  stani
// Created: Friday, 8 April 2022 21:25:31
// Purpose: Definition of Class CreateAppointmentDTO

using Model;
using System;

namespace Dto
{
    public class CreateAppointmentDTO
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Doctor Doctor { get; set; }
        public Room Room { get; set; }
        public AppointmentType Purpose { get; set; }
        public Patient Patient { get; set; }

    }
}