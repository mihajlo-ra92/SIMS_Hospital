// File:    PatientRepository.cs
// Author:  stani
// Created: Sunday, 3 April 2022 18:48:06
// Purpose: Definition of Class PatientRepository

using Dto;
using Exception;
using FileHandler;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class PatientRepository
    {
        public PatientFileHandler PatientFileHandler;
        public List<Patient> patients;

        public PatientRepository(PatientFileHandler patientFileHandler)
        {
            this.PatientFileHandler = patientFileHandler;
            patients = patientFileHandler.Read();
        }
        public List<Patient> ReadAll()
        {
            return patients;

      }
      
      public Patient ReadById(int patientId)
      {
         return  patients.Where(x => x.Id == patientId).FirstOrDefault();
      }


        public Patient ReadByUsername(string username)
        {
            return patients.Where(x => x.Username == username).FirstOrDefault();
        }
        public bool PatientExists(string username)
        {
            return patients.Any(x => x.Username == username);
        }
        public void Create(CreatePatientDTO newPatient)
        {
            Patient patient = new Patient()
            {
                Id = newPatient.Id,
                Username = newPatient.Username,
                Password = newPatient.Password,
                Email = newPatient.Email,
                Name = newPatient.Name,
                LastName = newPatient.LastName,
                BirthDate = newPatient.BirthDate,
                Gender = newPatient.Gender,
                IsGuest = newPatient.IsGuest,
            };
            patients.Add(patient);

            PatientFileHandler.Write(patients);
        }

        public void Edit(EditPatientDTO editPatient)
        {
            Patient patient = patients.Where(x => x.Id == editPatient.Id).First();

            patient.Username = editPatient.Username;
            patient.Password = editPatient.Password;
            patient.Email = editPatient.Email;
            patient.Name = editPatient.Name;
            patient.LastName = editPatient.LastName;
            patient.BirthDate = editPatient.BirthDate;
            patient.IsGuest = editPatient.IsGuest;
            patient.Gender = editPatient.Gender;

            PatientFileHandler.Write(patients);
        }

        public void Delete(int patientId)
        {
            Patient patient = patients.Where(x => x.Id == patientId).First();
            patients.Remove(patient);

            PatientFileHandler.Write(patients);
        }



    }
}