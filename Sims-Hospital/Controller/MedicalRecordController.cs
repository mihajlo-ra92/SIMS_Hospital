// File:    MedicalRecordController.cs
// Author:  stani
// Created: Tuesday, 5 April 2022 13:33:16
// Purpose: Definition of Class MedicalRecordController

using Dto;
using Model;
using Service;
using System;

namespace Controller
{
    public class MedicalRecordController
    {
        public MedicalRecordService MedicalRecordService { get; set; }
        public MedicalRecordController(MedicalRecordService medicalRecordService)
        {
            this.MedicalRecordService = medicalRecordService;
        }
        public void Create(MedicalRecordDTO newMedicalRecord)
        {
            MedicalRecordService.Create(newMedicalRecord);
        }

        public void Delete(int patientId)
        {
            MedicalRecordService.Delete(patientId);
        }
        public MedicalRecord ReadByPatientId(int patientId)
        {
            return MedicalRecordService.ReadByPatientId(patientId);
        }


    }
}