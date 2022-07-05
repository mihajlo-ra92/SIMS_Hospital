// File:    PatientController.cs
// Author:  stani
// Created: Sunday, 3 April 2022 19:04:42
// Purpose: Definition of Class PatientController

using Dto;
using Model;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class PatientController
    {
        public PatientService patientService { get; set; }

        public PatientController(PatientService patientService)
        {
            this.patientService = patientService;
        }
        public void Create(CreatePatientDTO newPatient)
        {
            patientService.Create(newPatient);
        }

        public String CheckNotifications(int patientId)
        {
            return patientService.CheckNotifications(patientId);
        }
        public List<Patient> ReadAll()
        {
            return patientService.ReadAll();
        }

        public Patient ReadById(int patientId)
        {
            return patientService.ReadById(patientId);
        }
        public Patient ReadByUsername(string username)
        {
            return patientService.ReadByUsername(username);
        }

        public void Edit(EditPatientDTO editPatient)
        {
            patientService.Edit(editPatient);
        }

        public string CheckNotification(int patientId)
        {
            return patientService.CheckNotifications(patientId);
        }

        public void Delete(int patientId)
        {
            patientService.Delete(patientId);
        }




    }
}