using Dto;
using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class FreeDayService
    {
        public FreeDayRepository FreeDayRepository;
        public DoctorRepository DoctorRepository;
        public SpecialistRepository SpecialistRepository;

        public FreeDayService(FreeDayRepository FreeDayRepository,
            DoctorRepository DoctorRepository, SpecialistRepository SpecialistRepository)
        {
            InitializeRepositories(FreeDayRepository, DoctorRepository, SpecialistRepository);
            ReadAll();
        }
        private void InitializeRepositories(FreeDayRepository FreeDayRepository,
            DoctorRepository DoctorRepository, SpecialistRepository SpecialistRepository)
        {
            this.FreeDayRepository = FreeDayRepository;
            this.DoctorRepository = DoctorRepository;
            this.SpecialistRepository = SpecialistRepository;

        }
        public List<FreeDay> ReadAll()
        {
            List<FreeDay> allFreeDays = FreeDayRepository.ReadAll();
            List<Doctor> allDoctors = DoctorRepository.ReadAll();
            BindDoctorsWithFreeDays(allDoctors, allFreeDays);
            return FreeDayRepository.ReadAll();
        }
        public void BindDoctorsWithFreeDays(IEnumerable<Doctor> allDoctors, IEnumerable<FreeDay> allFreeDays)
        {
            allFreeDays.ToList().ForEach(FreeDay =>
            {
                FreeDay.Doctor = FindDoctorById(allDoctors, FreeDay.Doctor.Id);
            });
        }
        private Doctor FindDoctorById(IEnumerable<Doctor> allDoctors, int id)
        {
            return allDoctors.SingleOrDefault(doctor => doctor.Id == id);
        }
        public void Create(CreateFreeDayDTO NewFreeDay)
        {
            FreeDayRepository.Create(NewFreeDay);
        }
        public FreeDay ReadById(int freeDayId)
        {
            return FreeDayRepository.ReadById(freeDayId);
        }
        public List<FreeDay> ReadByDoctorId(int doctorId)
        {
            return FreeDayRepository.ReadByDoctorId(doctorId);
        }
        public bool SameSpecialisationsHaveFreeDay(Doctor Doctor, DateTime StartDate, DateTime EndDate)
        {
            int numOfOverlaps = 0;
            foreach(FreeDay FreeDayIt in ReadAll())
            {
                //compare specialisation of sent doctor and of the doctor that requested free day
                if(SpecialistRepository.ReadById(FreeDayIt.Doctor.Id).Specialization.
                    Equals(SpecialistRepository.ReadById(Doctor.Id).Specialization))
                {
                    if (FreeDayIt.RequestState == RequestStateType.Accepted)
                    {
                        if (CheckOverlap(FreeDayIt.StartDate, FreeDayIt.EndDate, StartDate, EndDate))
                        {
                            numOfOverlaps++;
                            if (numOfOverlaps > 1)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        public bool CheckOverlap(DateTime aStart, DateTime aEnd, DateTime bStart, DateTime bEnd)
        {
            if (aStart.Date < bEnd.Date && bStart.Date < aEnd.Date)
            {
                    return true;
            }
            return false;
        }
    }
}
