// File:    AppointmentRepository.cs
// Author:  stani
// Created: Monday, 28 March 2022 19:25:48
// Purpose: Definition of Class AppointmentRepository

using Dto;
using FileHandler;
using Model;
using Sims_Hospital.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class AppointmentScheduleRepository
    {
        public AppointmentFileHandler AppointmentFileHandler = new AppointmentFileHandler();
        public List<Appointment> appointments;

        public AppointmentScheduleRepository()
        {
            appointments = AppointmentFileHandler.Read();
        }

        public bool IsRoomFree(int roomId, DateTime startTime, DateTime endTime, int appointmentId = -1)
        {
            foreach (Appointment appointmentIt in appointments)
            {
                if (appointmentIt.Room.Id == roomId && appointmentIt.Id != appointmentId)
                {
                    if (DateUtils.TimespansOverlap(appointmentIt.StartTime,
                        appointmentIt.EndTime, startTime, endTime))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool IsDoctorFree(int doctorId, DateTime startTime, DateTime endTime, int appointmentId = -1)
        {
            foreach (Appointment appointmentIt in appointments)
            {
                if (appointmentIt.Doctor.Id == doctorId && appointmentIt.Id != appointmentId)
                {
                    if (DateUtils.TimespansOverlap(appointmentIt.StartTime,
                        appointmentIt.EndTime, startTime, endTime))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool IsPatientFree(int patientId, DateTime startTime, DateTime endTime, int appointmentId = -1)
        {
            foreach (Appointment appointmentIt in appointments)
            {
                if (appointmentIt.Patient.Id == patientId && appointmentIt.Id != appointmentId)
                {
                    if (DateUtils.TimespansOverlap(appointmentIt.StartTime,
                        appointmentIt.EndTime, startTime, endTime))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
