// File:    DoctorService.cs
// Author:  stani
// Created: Tuesday, 5 April 2022 13:13:31
// Purpose: Definition of Class DoctorService

using Dto;
using Model;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
    public class DoctorService
    {
        public DoctorRepository DoctorRepository { get; set; }
        public UserRepository UserRepository { get; set; }

        public DoctorService(DoctorRepository doctorRepository, UserRepository userRepository)
        {
            this.DoctorRepository = doctorRepository;
            this.UserRepository = userRepository;
            ReadAll();
        }

        public List<Doctor> ReadAll()
        {
            List<Doctor> doctors = DoctorRepository.ReadAll();
            List<User> users = UserRepository.ReadAll();

            BindUsersWithDoctors(users, doctors);

            return doctors;
        }
        public List<Doctor> ReadAllNotSpecialist() 
        {
            List<Doctor> doctors = DoctorRepository.ReadAllNotSpecialist();
            List<User> users = UserRepository.ReadAll();
            BindUsersWithDoctors(users, doctors);
            return doctors;
        }

        private void BindUsersWithDoctors(List<User> users, List<Doctor> doctors)
        {
            doctors.ForEach(doctor => { FindDoctorAccount(users, doctor); });
        }

        private void FindDoctorAccount(List<User> users, Doctor doctor)
        {
            users.ForEach(user =>
            {
                if (user.Id == doctor.Id)
                {
                    doctor.Username = user.Username;
                    doctor.Password = user.Password;
                    doctor.Email = user.Email;
                    doctor.Name = user.Name;
                    doctor.LastName = user.LastName;
                    doctor.BirthDate = user.BirthDate;
                    doctor.Gender = user.Gender;
                }
            });
        }

        public Doctor ReadById(int doctorId)
        {
            return DoctorRepository.ReadById(doctorId);
        }
        public Doctor ReadByUsername(string username)
        {
            return DoctorRepository.ReadByUsername(username);
        }
        public void Create(CreateDoctorDTO newDoctor)
        {
            UserRepository.Create(newDoctor);
            newDoctor.Id = UserRepository.ReadByUsername(newDoctor.Username).Id;

            DoctorRepository.Create(newDoctor);
        }
        public void Edit(EditDoctorDTO editDoctor)
        {
            UserRepository.Edit(editDoctor);

            DoctorRepository.Edit(editDoctor);
        }
        public void Delete(int doctorId)
        {
            DoctorRepository.Delete(doctorId);
        }

        public List<Specialist> ReadAllSpecialist()
        {
            return DoctorRepository.ReadAllSpecialist();
        }

    }
}