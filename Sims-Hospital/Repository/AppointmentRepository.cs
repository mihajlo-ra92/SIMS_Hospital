// File:    AppointmentRepository.cs
// Author:  stani
// Created: Monday, 28 March 2022 19:25:48
// Purpose: Definition of Class AppointmentRepository

using Dto;
using FileHandler;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class AppointmentRepository
    {
        public AppointmentFileHandler AppointmentFileHandler = new AppointmentFileHandler();
        public List<Appointment> appointments;

        public AppointmentRepository()
        {
            appointments = AppointmentFileHandler.Read();
        }
        public List<Appointment> ReadAll()
        {
            return appointments;
        }

        public List<Appointment> ReadAllFinished()
        {
            List<Appointment> list = new List<Appointment>();
            foreach (Appointment appointment in appointments)
            {
                int time = DateTime.Compare(appointment.StartTime, DateTime.Now);
                if (time <= 0)
                {
                    list.Add(appointment);
                }
            }

            return list;
        }

        public List<Appointment> ReadByPatientId(int patientId)
        {
            return appointments.Where(x => x.Patient.Id == patientId).ToList();
        }
        public Appointment ReadById(int appointmentId)
        {
            return appointments.Where(x => x.Id == appointmentId).FirstOrDefault();
        }

        public List<Appointment> ReadByDoctorId(int doctorId)
        {
            return appointments.Where(x => x.Doctor.Id == doctorId).ToList();
        }
        public List<Appointment> ReadByDoctorIdAndStartDate(int doctorId, DateTime date)
        {
            return appointments.Where(x => x.Doctor.Id == doctorId && x.StartTime.Date == date.Date).ToList();
        }
        public List<Appointment> ReadByStartDate(DateTime date)
        {
            return appointments.Where(x => x.StartTime.Date == date.Date).ToList();
        }
        public List<Appointment> ReadByRoomId(int roomId)
        {
            return appointments.Where(x => x.Room.Id == roomId).ToList();
        }

        public void Create(CreateAppointmentDTO NewAppointment)
        {
            int id = 0;
            if (appointments.Count > 0)
            {
                id = appointments.Max(x => x.Id) + 1;
            }
            Appointment appointment = new Appointment()
            {
                Id = id,
                StartTime = NewAppointment.StartTime,
                EndTime = NewAppointment.EndTime,
                Purpose = NewAppointment.Purpose,
                Doctor = NewAppointment.Doctor,
                Patient = NewAppointment.Patient,
                Room = NewAppointment.Room,
            };
            appointments.Add(appointment);
            AppointmentFileHandler.Write(appointments);
        }
        public void CreateByPatient(CreateAppointmentPatientDTO NewAppointment,Room room)
        {
            Appointment appointment = new Appointment()
            {
                Id = appointments.Count + 1,
                StartTime = NewAppointment.StartTime,
                EndTime = NewAppointment.StartTime.AddMinutes(20),
                Doctor = NewAppointment.Doctor,
                Purpose = AppointmentType.CheckUp,
                //treba da iscita iz liste soba
                Room = room,
                Patient = NewAppointment.Patient,
            };
            appointments.Add(appointment);
            AppointmentFileHandler.Write(appointments);
        }

        public void Edit(EditAppointmentDTO editAppointment)
        {
            Appointment appointment = appointments.Where(x => x.Id == editAppointment.Id).First();
            appointment.StartTime = editAppointment.StartTime;
            appointment.EndTime = editAppointment.EndTime;
            appointment.Purpose = editAppointment.Purpose;
            appointment.Doctor = editAppointment.Doctor;
            appointment.Patient = editAppointment.Patient;
            appointment.Room = editAppointment.Room;
            AppointmentFileHandler.Write(appointments);
        }

        public void EditByPatient(EditAppointmentPatientDTO EditAppointmentPatientDTO,Room room)
        {
            Appointment appointment = appointments.Where(x => x.Id == EditAppointmentPatientDTO.Id).First();

            appointment.StartTime = EditAppointmentPatientDTO.StartTime;
            appointment.EndTime = EditAppointmentPatientDTO.StartTime.AddMinutes(20);
            appointment.Doctor = EditAppointmentPatientDTO.Doctor;
            appointment.Patient = EditAppointmentPatientDTO.Patient;
            appointment.Purpose = AppointmentType.CheckUp;
            appointment.Room = room;


            AppointmentFileHandler.Write(appointments);
        }

        public void Delete(int appointmentId)
        {
            var appointment = appointments.Where(x => x.Id == appointmentId).First();
            appointments.Remove((Appointment)appointment);
            AppointmentFileHandler.Write(appointments);
        }

        public List<Appointment> ReadFromDateToDate(DateTime start, DateTime end)
        {
            return appointments.Where(x => DateTime.Compare(start, x.StartTime) < 0 && DateTime.Compare(end, x.EndTime) > 0).ToList();
        }

    }
}