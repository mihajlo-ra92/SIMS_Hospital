// File:    EditAppointmentDTO.cs
// Author:  stani
// Created: Friday, 8 April 2022 21:25:31
// Purpose: Definition of Class EditAppointmentDTO

using Model;
using System;

namespace Dto
{
   public class EditAppointmentDTO
   {
      public int Id { get; set; }
      public DateTime StartTime { get; set; }
      public DateTime EndTime { get; set; }
      public Doctor Doctor { get; set; }
      public Room Room { get; set; }
      public AppointmentType Purpose { get; set; }
      public Model.Patient Patient { get; set; }
   
   }

}