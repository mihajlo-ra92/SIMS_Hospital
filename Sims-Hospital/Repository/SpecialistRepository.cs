// File:    SpecialistRepository.cs
// Author:  stani
// Created: Sunday, 3 April 2022 18:48:07
// Purpose: Definition of Class SpecialistRepository

using Dto;
using FileHandler;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class SpecialistRepository
    {
        public SpecialistFileHandler SpecialistFileHandler = new SpecialistFileHandler();
        public List<Specialist> specialists;

        public SpecialistRepository()
        {
            specialists = SpecialistFileHandler.Read();
        }
        public void Create(CreateSpecialistDTO newSpecialist)
        {
            int id = 0;
            if (specialists.Count > 0)
            {
                id = specialists.Max(x => x.Id) + 1;
            }
            Specialist specialist = new Specialist()
            {
                Id = id,
                Username = newSpecialist.Username,
                Password = newSpecialist.Password,
                Email = newSpecialist.Email,
                Name = newSpecialist.Name,
                LastName = newSpecialist.LastName,
            };
            specialists.Add(specialist);

            SpecialistFileHandler.Write(specialists);
        }
        public void Edit(EditSpecialistDTO editSpecialist)
        {
            Specialist specialist = specialists.Where(x => x.Id == editSpecialist.Id).First();
            specialist.Username = editSpecialist.Username;
            specialist.Password = editSpecialist.Password;
            specialist.Email = editSpecialist.Email;
            specialist.Name = editSpecialist.Name;
            specialist.LastName = editSpecialist.LastName;

            SpecialistFileHandler.Write(specialists);
        }
        public void Delete(int doctorId)
        {
            var specialist = specialists.Where(x => x.Id == doctorId);
            specialists.Remove((Specialist)specialist);

            SpecialistFileHandler.Write(specialists);
        }
        public List<Specialist> ReadAll()
        {
            return specialists;
        }
        public Specialist ReadById(int specialistId)
        {
            return specialists.Where(x => x.Id == specialistId).First();
        }
        public Specialist ReadByUsername(string username)
        {
            return specialists.Where(x => x.Username == username).FirstOrDefault();
        }
    }
}