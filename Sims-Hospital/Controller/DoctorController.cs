// File:    DoctorController.cs
// Author:  stani
// Created: Sunday, 3 April 2022 19:04:42
// Purpose: Definition of Class DoctorController

using Dto;
using Model;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class DoctorController
    {
        public DoctorService DoctorService { get; set; }

        public DoctorController(DoctorService doctorService)
        {
            this.DoctorService = doctorService;
        }
        public void Create(CreateDoctorDTO newDoctor)
        {
            DoctorService.Create(newDoctor);
        }

        public List<Doctor> ReadAll()
        {
            return DoctorService.ReadAll();
        }
        public List<Doctor> ReadAllSpecialist(Doctor Doctor)
        {
            List<Specialist> allSpecialist = DoctorService.ReadAllSpecialist();
            List<Doctor> result = new List<Doctor>();
            String special = null;

            foreach (Specialist each in allSpecialist)
            {
                if (Doctor.Id == each.Id)
                {
                    special = each.Specialization;
                    break;
                }
            }

            List<int> ListId = new List<int>();

            foreach (Specialist each in allSpecialist)
            {
                if (each.Specialization == special)
                {
                    ListId.Add(each.Id);
                }
            }

            for (int i = 0; i < ListId.Count; i++)
            {
                int index = ListId[i];
                Doctor doctor = DoctorService.ReadById(index);
                result.Add(doctor);
            }

            return result;
        }
        public List<Doctor> ReadAllNotSpecialist()
        {
            return DoctorService.ReadAllNotSpecialist();
        }

        public Doctor ReadById(int doctorId)
        {
            return DoctorService.ReadById(doctorId);
        }
        public Doctor ReadByUsername(string username)
        {
            return DoctorService.ReadByUsername(username);
        }

        public void Edit(EditDoctorDTO editDoctor)
        {
            DoctorService.Edit(editDoctor);
        }

        public void Delete(int doctorId)
        {
            DoctorService.Delete(doctorId);
        }
    }
}