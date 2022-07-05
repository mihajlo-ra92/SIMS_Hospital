// File:    GuestMedicalRecord.cs
// Author:  stani
// Created: Tuesday, 5 April 2022 13:07:13
// Purpose: Definition of Class GuestMedicalRecord

using Controller;
using Sims_Hospital;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace Model
{
    public class GuestMedicalRecordViewModel : BindableBase
    {
        private PatientController PatientController;
        private MedicalRecordController MedicalRecordController;
        private GuestMedicalRecordController GuestMedicalRecordController;
        private AllergiesController AllergiesController;
        public ObservableCollection<string> PatientAllergies { get; set; }
        public ObservableCollection<string> patientAllergies { get; set; }
        public ObservableCollection<Patient> Patients { get; set; }
        public Patient selectedPatient;
        public string firstLastName { get; set; }
        public string parentName { get; set; }
        public string umcn { get; set; }
        public string Address { get; set; }
        public string bloodType { get; set; }

        public string Umcn
        {
            get { return umcn; }
            set
            {
                if (umcn != value)
                {
                    umcn = value;
                    OnPropertyChanged("Umcn");
                }
            }
        }
        public string BloodType
        {
            get { return bloodType; }
            set
            {
                if (bloodType != value)
                {
                    bloodType = value;
                    OnPropertyChanged("BloodType");
                }
            }
        }
        public string ParentName
        {
            get { return parentName; }
            set
            {
                if (parentName != value)
                {
                    parentName = value;
                    OnPropertyChanged("ParentName");
                }
            }
        }
        public string FirstLastName
        {
            get { return firstLastName; }
            set
            {
                if (firstLastName != value)
                {
                    firstLastName = value;
                    OnPropertyChanged("FirstLastName");
                }
            }
        }
        public Patient SelectedPatient
        {
            get { return selectedPatient; }
            set
            {
                selectedPatient = value;
                SelectedPatientChanged();
            }
        }
        public GuestMedicalRecordViewModel()
        {
            LoadPatients();
            //LoadFields();
        }
        public void LoadPatients()
        {
            var app = Application.Current as App;
            PatientController = app.PatientController;
            GuestMedicalRecordController = app.GuestMedicalRecordController;
            MedicalRecordController = app.MedicalRecordController;
            AllergiesController = app.AllergiesController;
            ObservableCollection<Patient> patients = new ObservableCollection<Patient>();


            patientAllergies = new ObservableCollection<string>();
            patientAllergies.Add("---");
            PatientAllergies = patientAllergies;


            foreach (Patient patientIt in PatientController.ReadAll())
            {
                patients.Add(patientIt);
            }
            Patients = patients;
        }
        public void SelectedPatientChanged()
        {
            if (SelectedPatient != null)
            {
                LoadFields();
            }
        }
        public void LoadFields()
        {

            if (selectedPatient.IsGuest)
            {
                GuestMedicalRecord guestMedicalRecord = GuestMedicalRecordController.ReadByPatientId(selectedPatient.Id);
                FirstLastName = selectedPatient.NameLastName;
                Umcn = guestMedicalRecord.Umcn;
                ParentName = "---";
                BloodType = guestMedicalRecord.BloodType.ToString();
                Address = "---";
                patientAllergies.Clear();
                foreach (string allergyIt in AllergiesController.PrintById(selectedPatient.Id))
                {
                    patientAllergies.Add(allergyIt);
                }
                PatientAllergies = patientAllergies;
            }
            else
            {
                MedicalRecord medicalRecord = MedicalRecordController.ReadByPatientId(selectedPatient.Id);
                FirstLastName = selectedPatient.NameLastName;
                Umcn = medicalRecord.Umcn;
                ParentName = medicalRecord.ParentName;
                BloodType = medicalRecord.BloodType.ToString();
                Address = medicalRecord.Address.ToString();
                patientAllergies.Clear();
                foreach (string allergyIt in AllergiesController.PrintById(selectedPatient.Id))
                {
                    patientAllergies.Add(allergyIt);
                }
                PatientAllergies = patientAllergies;
            }
        }

    }
}