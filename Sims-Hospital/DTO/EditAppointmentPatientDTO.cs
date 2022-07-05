// File:    EditAppointmentPatientDTO.cs
// Author:  stani
// Created: Friday, 8 April 2022 21:25:31
// Purpose: Definition of Class EditAppointmentPatientDTO

using Model;
using System;

namespace Dto
{

   public class EditAppointmentPatientDTO
   {
      public int Id { get; set; }
      public DateTime StartTime { get; set; }
      public Doctor Doctor { get; set; }
      public Model.Patient Patient { get; set; }
   
   }
    //NEKO DOPISIVAO CEO DTO?
 //   public class EditAppointmentPatientDTO
//    {
//        public int Id { get; set; }
//        public DateTime StartTime { get; set; }
//        public Doctor Doctor { get; set; }
//        public AppointmentType Purpose { get; set; }
//        public Model.Patient Patient { get; set; }
//
//    }

}