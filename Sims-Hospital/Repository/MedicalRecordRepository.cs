// File:    MedicalRecordRepository.cs
// Author:  stani
// Created: Sunday, 3 April 2022 18:48:07
// Purpose: Definition of Class MedicalRecordRepository

using Dto;
using FileHandler;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class MedicalRecordRepository
    {
        public MedicalRecordFileHandler MedicalRecordFileHandler;
        public List<MedicalRecord> medicalRecords;

        public MedicalRecordRepository(MedicalRecordFileHandler medicalFileHandler)
        {
            this.MedicalRecordFileHandler = medicalFileHandler;
            medicalRecords = MedicalRecordFileHandler.Read();
        }
        public List<MedicalRecord> ReadAll()
        {
            return medicalRecords;
        }
        public void Create(MedicalRecordDTO newMedicalRecord)
        {
            int id = 0;
            if (medicalRecords.Count > 0)
            {
                id = medicalRecords.Max(x => x.Id) + 1;
            }
            MedicalRecord medicalRecord = new MedicalRecord()
            {
                Id = id,
                Umcn = newMedicalRecord.Umcn,
                Allergies = newMedicalRecord.Allergies,
                BloodType = newMedicalRecord.BloodType,
                ParentName = newMedicalRecord.ParentName,
                Address = newMedicalRecord.Address,
                Patient = newMedicalRecord.Patient,
            };
            medicalRecords.Add(medicalRecord);

            MedicalRecordFileHandler.Write(medicalRecords);
        }

        public MedicalRecord ReadByPatientId(int patientId)
        {
            return medicalRecords.Where(x => x.Patient.Id == patientId).FirstOrDefault();
        }

        public void Delete(int patientId)
        {
            var medicalRecord = medicalRecords.Where(x => x.Id == patientId);
            medicalRecords.Remove((MedicalRecord)medicalRecord);

            MedicalRecordFileHandler.Write(medicalRecords);
        }
    }
}