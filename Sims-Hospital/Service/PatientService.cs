// File:    PatientService.cs
// Author:  stani
// Created: Sunday, 3 April 2022 18:55:48
// Purpose: Definition of Class PatientService

using Dto;
using Model;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
    public class PatientService
    {
        public PatientRepository patientRepository { get; set; }
        public GuestMedicalRecordRepository guestMedicalRecordRepository { get; set; }
        public MedicalRecordRepository medicalRecordRepository { get; set; }
        public UserRepository userRepository { get; set; }
        public PrescriptionRepository prescriptionRepository { get; set; } 
        public AppointmentRepository appointmentRepository { get; set; }


        public PatientService(PatientRepository patientRepository, GuestMedicalRecordRepository guestMedicalRecordRepository, MedicalRecordRepository medicalRecordRepository, UserRepository userRepository,PrescriptionRepository prescriptionRepository,AppointmentRepository appointmentRepository)
        {
            this.patientRepository = patientRepository;
            this.guestMedicalRecordRepository = guestMedicalRecordRepository;
            this.medicalRecordRepository = medicalRecordRepository;
            this.userRepository = userRepository;
            this.prescriptionRepository = prescriptionRepository;
            this.appointmentRepository = appointmentRepository;
            ReadAll();
        }

        

        public String CheckNotifications(int patientId)
        {
            List<Prescription> prescriptions = prescriptionRepository.ReadByPatientId(patientId);
            foreach (Prescription prescription in prescriptions)
            {
                if(DateTime.Compare(DateTime.Today, prescription.StartDate) >= 0 && DateTime.Compare(DateTime.Today, prescription.EndDate) <= 0)
                {
                    List<int> Times = new List<int>();
                    for (int i = 0; i < prescription.TimesADay; i++)
                    {
                        int Duration = 24 / prescription.TimesADay;
                        int time = i * Duration;
                        Times.Add(time);
                    }
                    foreach (int time in Times)
                    {
                        DateTime now = DateTime.Now.AddMinutes(30);
                        if (now.Hour == time && now.Minute == 0)
                        {
                            return prescription.Medicine;
                            break;
                        }
                    }
                }
            }
            return null;
        }

        public void Create(CreatePatientDTO newPatient)
        {
            userRepository.Create(newPatient);
            newPatient.Id = userRepository.ReadByUsername(newPatient.Username).Id;

            patientRepository.Create(newPatient);
        }

        public List<Patient> ReadAll()
        {
            List<Patient> patients = patientRepository.ReadAll();
            List<User> users = userRepository.ReadAll();

            BindUsersWithPatients(users, patients);

            return patients;
        }

        private void BindUsersWithPatients(List<User> users, List<Patient> patients)
        {
            patients.ForEach(patient => { FindPatientAccount(users, patient); });
        }

        private void FindPatientAccount(List<User> users, Patient patient)
        {
            users.ForEach(user => 
            { 
                if(user.Id == patient.Id)
                {
                    patient.Username = user.Username;
                    patient.Password = user.Password;
                    patient.Email = user.Email;
                    patient.Name = user.Name;
                    patient.LastName = user.LastName;
                    patient.BirthDate = user.BirthDate;
                    patient.Gender = user.Gender;
                }
            });
        }

        public Patient ReadById(int patientId)
        {
            return patientRepository.ReadById(patientId);
        }
        public Patient ReadByUsername(string username)
        {
            return patientRepository.ReadByUsername(username);
        }
        public void Edit(EditPatientDTO editPatient)
        {
            userRepository.Edit(editPatient);

            patientRepository.Edit(editPatient);
        }

        public void Delete(int patientId)
        {
            Patient patient = patientRepository.ReadById(patientId);
            if (patient.IsGuest == false)
            {
                medicalRecordRepository.Delete(patientId);
            }else
            {
                guestMedicalRecordRepository.Delete(patientId);
            }
            patientRepository.Delete(patientId);
            userRepository.Delete(patientId);
        }

    }
}