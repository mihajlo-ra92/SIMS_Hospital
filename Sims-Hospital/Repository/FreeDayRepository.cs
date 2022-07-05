using Dto;
using FileHandler;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class FreeDayRepository
    {
        public FreeDayFileHandler FreeDayFileHandler = new FreeDayFileHandler();
        public List<FreeDay> freeDays;
        
        public FreeDayRepository()
        {
            freeDays = FreeDayFileHandler.Read();
        }
        public List<FreeDay> ReadAll()
        {
            return freeDays;
        }
        public FreeDay ReadById(int freeDayId)
        {
            return freeDays.Where(x => x.Id == freeDayId).FirstOrDefault();
        }
        public List<FreeDay> ReadByDoctorId(int doctorId)
        {
            return freeDays.Where(x => x.Doctor.Id == doctorId).ToList();
        }
        public void Create(CreateFreeDayDTO NewFreeDay)
        {
            FreeDay FreeDay = new FreeDay()
            {
                Id = freeDays.Count + 1,
                Doctor = NewFreeDay.Doctor,
                StartDate = NewFreeDay.StartDate,
                EndDate = NewFreeDay.EndDate,
                Note = NewFreeDay.Note,
                IsEmergency = NewFreeDay.IsEmergency,
                RequestState = NewFreeDay.RequestState,
                DecisionNote = "",
            };
            freeDays.Add(FreeDay);
            FreeDayFileHandler.Write(freeDays);
        }
    }
}
