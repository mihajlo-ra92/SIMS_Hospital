// File:    GuestMedicalRecordService.cs
// Author:  stani
// Created: Tuesday, 5 April 2022 13:13:31
// Purpose: Definition of Class GuestMedicalRecordService

using Dto;
using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class GuestMedicalRecordService
    {
        public GuestMedicalRecordRepository guestMedicalRecordRepository { get; set; }
        public PatientService patientService { get; set; }

        public AllergiesService allergiesService { get; set; }

        public GuestMedicalRecordService(GuestMedicalRecordRepository guestMedicalRecordRepository, PatientService patientService, AllergiesService allergiesService)
        {
            this.guestMedicalRecordRepository = guestMedicalRecordRepository;
            this.patientService = patientService;
            this.allergiesService = allergiesService;
            ReadAll();
        }

        public void Create(GuestMedicalRecordDTO newMedicalRecord)
        {
            guestMedicalRecordRepository.Create(newMedicalRecord);
        }
        public List<GuestMedicalRecord> ReadAll()
        {
            var patients = patientService.ReadAll();
            var allergies = allergiesService.ReadAll();
            var guestMedicalRecords = guestMedicalRecordRepository.ReadAll();

            BindPatientsWithGuestMedicalRecords(patients, guestMedicalRecords);
            BindAllergiesWithGuestMedicalRecords(allergies, guestMedicalRecords);

            return guestMedicalRecordRepository.ReadAll();
        }
        public void BindPatientsWithGuestMedicalRecords(IEnumerable<Patient> patients, IEnumerable<GuestMedicalRecord> guestMedicalRecords)
        {
            guestMedicalRecords.ToList().ForEach(guestMedicalRecord =>
            {
                guestMedicalRecord.Patient = FindPatientById(patients, guestMedicalRecord.Patient.Id);
            });
        }

        public void BindAllergiesWithGuestMedicalRecords(IEnumerable<PatientAllergies> allergies, IEnumerable<GuestMedicalRecord> guestMedicalRecords)
        {
            guestMedicalRecords.ToList().ForEach(guestMedicalRecord => 
            {
                guestMedicalRecord.Allergies = FindAllergiesByPatientId(allergies, guestMedicalRecord.Patient.Id);
            });
        }

        private PatientAllergies FindAllergiesByPatientId(IEnumerable<PatientAllergies> allergies, int id)
        {
            return allergies.SingleOrDefault(a => a.Patient.Id == id);
        }

        private Patient FindPatientById(IEnumerable<Patient> patients, int id)
        {
            return patients.SingleOrDefault(patient => patient.Id == id);
        }
        public void Delete(int patientId)
        {
            guestMedicalRecordRepository.Delete(patientId);
        }
        public GuestMedicalRecord ReadByPatientId(int patientId)
        {
            return guestMedicalRecordRepository.ReadByPatientId(patientId);
        }

    }
}