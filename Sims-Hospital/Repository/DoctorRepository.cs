// File:    DoctorRepository.cs
// Author:  stani
// Created: Sunday, 3 April 2022 18:48:07
// Purpose: Definition of Class DoctorRepository

using Dto;
using FileHandler;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class DoctorRepository
    {
        public DoctorFileHandler DoctorFileHandler = new DoctorFileHandler();
        public SpecialistFileHandler SpecialistFileHandler = new SpecialistFileHandler();
        public List<Doctor> doctors;
        public List<Specialist> specialists;

        public DoctorRepository()
        {
            ReadFromFilehandlers();
        }
        private void ReadFromFilehandlers()
        {
            doctors = DoctorFileHandler.Read();
            specialists = SpecialistFileHandler.Read();

        }
        public void Create(CreateDoctorDTO newDoctor)
        {
            Doctor doctor = new Doctor()
            {
                Id = newDoctor.Id,
                Username = newDoctor.Username,
                Password = newDoctor.Password,
                Email = newDoctor.Email,
                Name = newDoctor.Name,
                LastName = newDoctor.LastName,
            };
            doctors.Add(doctor);

            DoctorFileHandler.Write(doctors);
        }
        public void Edit(EditDoctorDTO editDoctor)
        {
            Doctor doctor = doctors.Where(x => x.Id == editDoctor.Id).First();
            doctor.Username = editDoctor.Username;
            doctor.Password = editDoctor.Password;
            doctor.Email = editDoctor.Email;
            doctor.Name = editDoctor.Name;
            doctor.LastName = editDoctor.LastName;

            DoctorFileHandler.Write(doctors);
        }
        public void Delete(int doctorId)
        {
            var doctor = doctors.Where(x => x.Id == doctorId);
            doctors.Remove((Doctor)doctor);

            DoctorFileHandler.Write(doctors);
        }
        public List<Doctor> ReadAll()
        {
            return doctors;
        }

        public List<Specialist> ReadAllSpecialist()
        {
            return specialists;
        }
        public List<Doctor> ReadAllNotSpecialist()
        {
            return doctors.Where(x => x.isSpecialist == false).ToList();
        }
        public Doctor ReadById(int doctorId)
        {
            return doctors.Where(x => x.Id == doctorId).FirstOrDefault();
        }
        public Doctor ReadByUsername(string username)
        {
            return doctors.Where(x => x.Username == username).FirstOrDefault();
        }
    }
}