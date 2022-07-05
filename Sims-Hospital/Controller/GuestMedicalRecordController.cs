// File:    GuestMedicalRecordController.cs
// Author:  stani
// Created: Tuesday, 5 April 2022 13:33:17
// Purpose: Definition of Class GuestMedicalRecordController

using Dto;
using Model;
using Service;
using System;

namespace Controller
{
    public class GuestMedicalRecordController
    {
        public GuestMedicalRecordService GuestMedicalRecordService { get; set; }
        public GuestMedicalRecordController(GuestMedicalRecordService guestMedicalRecordService)
        {
            GuestMedicalRecordService = guestMedicalRecordService;
        }
        public void Create(GuestMedicalRecordDTO newMedicalRecord)
        {
            GuestMedicalRecordService.Create(newMedicalRecord);
        }

        public void Delete(int patientId)
        {
            GuestMedicalRecordService.Delete(patientId);
        }
        public GuestMedicalRecord ReadByPatientId(int patientId)
        {
            return GuestMedicalRecordService.ReadByPatientId(patientId);
        }
    }
}