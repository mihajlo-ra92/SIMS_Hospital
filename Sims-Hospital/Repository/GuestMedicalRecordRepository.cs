// File:    GuestMedicalRecordRepository.cs
// Author:  stani
// Created: Sunday, 3 April 2022 18:48:07
// Purpose: Definition of Class GuestMedicalRecordRepository

using Dto;
using FileHandler;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class GuestMedicalRecordRepository
    {
        public GuestMedicalRecordFileHandler GuestMedicalRecordFileHandler;
        public List<GuestMedicalRecord> medicalRecords;

        public GuestMedicalRecordRepository(GuestMedicalRecordFileHandler guestMedicalFileHandler)
        {
            this.GuestMedicalRecordFileHandler = guestMedicalFileHandler;
            medicalRecords = GuestMedicalRecordFileHandler.Read();
        }
        public List<GuestMedicalRecord> ReadAll()
        {
            return medicalRecords;
        }
        public void Create(GuestMedicalRecordDTO newMedicalRecord)
        {
            int id = 0;
            if (medicalRecords.Count > 0)
            {
                id = medicalRecords.Max(x => x.Id) + 1;
            }
            GuestMedicalRecord medicalRecord = new()
            {
                Id = id,
                Umcn = newMedicalRecord.Umcn,
                Allergies = newMedicalRecord.Allergies,
                BloodType = newMedicalRecord.BloodType,
                Patient = newMedicalRecord.Patient,
            };
            medicalRecords.Add(medicalRecord);

            GuestMedicalRecordFileHandler.Write(medicalRecords);
        }
        public GuestMedicalRecord ReadByPatientId(int patientId)
        {
            return medicalRecords.Where(x => x.Patient.Id == patientId).FirstOrDefault();
        }

        public void Delete(int patientId)
        {
            var medicalRecord = medicalRecords.Where(x => x.Id == patientId);
            medicalRecords.Remove((GuestMedicalRecord)medicalRecord);

            GuestMedicalRecordFileHandler.Write(medicalRecords);
        }



    }
}