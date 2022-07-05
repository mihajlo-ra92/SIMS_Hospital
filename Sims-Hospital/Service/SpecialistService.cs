// File:    SpecialistService.cs
// Author:  stani
// Created: Tuesday, 5 April 2022 13:13:31
// Purpose: Definition of Class SpecialistService

using Dto;
using Model;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
    public class SpecialistService
    {
        public SpecialistRepository SpecialistRepository { get; set; }

        public SpecialistService(SpecialistRepository specialistRepository)
        {
            SpecialistRepository = specialistRepository;
        }

        public List<Specialist> ReadAll()
        {
            return SpecialistRepository.ReadAll();
        }
        public Doctor ReadById(int specialistId)
        {
            return SpecialistRepository.ReadById(specialistId);
        }
        public Doctor ReadByUsername(string username)
        {
            return SpecialistRepository.ReadByUsername(username);
        }
        public void Create(CreateSpecialistDTO newSpecialist)
        {
            SpecialistRepository.Create(newSpecialist);
        }
        public void Edit(EditSpecialistDTO editSpecialist)
        {
            SpecialistRepository.Edit(editSpecialist);
        }
        public void Delete(int specialistId)
        {
            SpecialistRepository.Delete(specialistId);
        }

    }
}