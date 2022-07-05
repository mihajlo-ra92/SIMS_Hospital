// File:    MedicalRecordService.cs
// Author:  stani
// Created: Tuesday, 5 April 2022 13:13:31
// Purpose: Definition of Class MedicalRecordService

using Dto;
using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class MedicalRecordService
    {
        public MedicalRecordRepository medicalRecordRepository { get; set; }
        public PatientRepository patientRepository { get; set; }

        public AllergiesRepository allergiesRepository { get; set; }

        public MedicalRecordService(MedicalRecordRepository medicalRecordRepository, PatientRepository patientRepository, AllergiesRepository allergiesRepository)
        {
            this.medicalRecordRepository = medicalRecordRepository;
            this.patientRepository = patientRepository;
            this.allergiesRepository = allergiesRepository;
            ReadAll();
        }
        public void Create(MedicalRecordDTO newMedicalRecord)
        {
            medicalRecordRepository.Create(newMedicalRecord);
        }
        public List<MedicalRecord> ReadAll()
        {
            var patients = patientRepository.ReadAll();
            var allergies = allergiesRepository.ReadAll();
            var medicalRecords = medicalRecordRepository.ReadAll();

            BindPatientsWithMedicalRecords(patients, medicalRecords);
            BindAllergiesWithMedicalRecords(allergies, medicalRecords);

            return medicalRecordRepository.ReadAll();
        }

        public void BindAllergiesWithMedicalRecords(IEnumerable<PatientAllergies> allergies, IEnumerable<MedicalRecord> medicalRecords)
        {
            medicalRecords.ToList().ForEach(medicalRecord =>
            {
                medicalRecord.Allergies = FindAllergiesByPatientId(allergies, medicalRecord.Patient.Id);
            });
        }

        private PatientAllergies FindAllergiesByPatientId(IEnumerable<PatientAllergies> allergies, int id)
        {
            return allergies.SingleOrDefault(a => a.Patient.Id == id);
        }


        public void BindPatientsWithMedicalRecords(IEnumerable<Patient> patients, IEnumerable<MedicalRecord> medicalRecords)
        {
            medicalRecords.ToList().ForEach(medicalRecord =>
            {
                medicalRecord.Patient = FindPatientById(patients, medicalRecord.Patient.Id);
            });
        }
        private Patient FindPatientById(IEnumerable<Patient> patients, int id)
        {
            return patients.SingleOrDefault(patient => patient.Id == id);
        }
        public void Delete(int patientId)
        {
            medicalRecordRepository.Delete(patientId);
        }
        public MedicalRecord ReadByPatientId(int patientId)
        {
            return medicalRecordRepository.ReadByPatientId(patientId);
        }

    }
}