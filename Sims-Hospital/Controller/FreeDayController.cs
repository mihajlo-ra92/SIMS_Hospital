using Dto;
using Model;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class FreeDayController
    {
        public FreeDayService FreeDayService;

        public FreeDayController(FreeDayService FreeDayService)
        {
            this.FreeDayService = FreeDayService;
        }
        public void Create(CreateFreeDayDTO NewFreeDay)
        {
            FreeDayService.Create(NewFreeDay);
        }
        public List<FreeDay> ReadAll()
        {
            return FreeDayService.ReadAll();
        }
        public List<FreeDay> ReadByDoctorId(int id)
        {
            return FreeDayService.ReadByDoctorId(id);
        }
        public bool SameSpecialisationsHaveFreeDay(Doctor Doctor, DateTime StartDate, DateTime EndDate)
        {
            return FreeDayService.SameSpecialisationsHaveFreeDay(Doctor, StartDate, EndDate);
        }


    }
}
