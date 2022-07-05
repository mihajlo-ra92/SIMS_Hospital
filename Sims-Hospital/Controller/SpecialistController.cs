// File:    SpecialistController.cs
// Author:  stani
// Created: Sunday, 3 April 2022 19:04:42
// Purpose: Definition of Class SpecialistController

using Dto;
using Model;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class SpecialistController
    {
        public SpecialistService SpecialistService { get; set; }

        public SpecialistController(SpecialistService specialistService)
        {
            this.SpecialistService = specialistService;
        }
        public void Create(CreateSpecialistDTO newSpecialist)
        {
            SpecialistService.Create(newSpecialist);
        }

        public List<Specialist> ReadAll()
        {
            return SpecialistService.ReadAll();
        }

        public Specialist ReadById(int specialistId)
        {
            return (Specialist)SpecialistService.ReadById(specialistId);
        }
        public Specialist ReadByUsername(string username)
        {
            return (Specialist)SpecialistService.ReadByUsername(username);
        }

        public void Edit(EditSpecialistDTO editSpecialist)
        {
            SpecialistService.Edit(editSpecialist);
        }

        public void Delete(int specialistId)
        {
            SpecialistService.Delete(specialistId);
        }
    }
}