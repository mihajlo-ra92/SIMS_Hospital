// File:    AppointmentController.cs
// Author:  stani
// Created: Monday, 28 March 2022 19:41:53
// Purpose: Definition of Class AppointmentController

using Dto;
using Model;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class AppointmentController
    {
        public AppointmentService AppointmentService;

        public AppointmentController(AppointmentService appointmentService)
        {
            AppointmentService = appointmentService;
        }
        public void Create(CreateAppointmentDTO newAppointment)
        {
            AppointmentService.Create(newAppointment);
        }

        public void CreateByPatient(CreateAppointmentPatientDTO newAppointment)
        {
            AppointmentService.CreateByPatient(newAppointment);
        }

        public List<Appointment> ReadAll()
        {
            return AppointmentService.ReadAll();
        }

        public Appointment ReadById(int appointmentId)
        {
            return AppointmentService.ReadById(appointmentId);
        }
        public List<Appointment> ReadByDoctorId(int doctorId)
        {
            return AppointmentService.ReadByDoctorId(doctorId);
        }
        public List<Appointment> ReadByDoctorIdAndStartDate(int doctorId, DateTime date)
        {
            return AppointmentService.ReadbyDoctorIdAndStartDate(doctorId, date);
        }
        public List<Appointment> ReadByStartDate(DateTime date)
        {
            return AppointmentService.ReadByStartDate(date);
        }
        public void Edit(EditAppointmentDTO editAppointment)
        {
            AppointmentService.Edit(editAppointment);
        }

        public void EditByPatient(EditAppointmentPatientDTO EditAppointmentPatientDTO)
        {
            AppointmentService.EditByPatient(EditAppointmentPatientDTO);
        }
        public void Delete(int appointmentId)
        {
            AppointmentService.Delete(appointmentId);
        }
        public void StartAppointment(int appointmentId)
        {
            throw new NotImplementedException();
        }

        public bool IsRoomFree(int roomId, DateTime startTime, DateTime endTime, int appointmentId = -1)
        {
            return AppointmentService.IsRoomFree(roomId, startTime, endTime, appointmentId);
        }
        public bool IsDoctorFree(int doctorId, DateTime startTime, DateTime endTime, int appointmentId = -1)
        {
            return AppointmentService.IsDoctorFree(doctorId, startTime, endTime, appointmentId);
        }
        public bool IsPatientFree(int patientId, DateTime startTime, DateTime endTime, int appointmentId = -1)
        {
            return AppointmentService.IsPatientFree(patientId, startTime, endTime, appointmentId);
        }

        public void EndAppointment(int appointmentId)
        {
            throw new NotImplementedException();
        }
        public bool DoctorHasAppointment(Doctor Doctor, DateTime StartDate, DateTime EndDate)
        {
            return AppointmentService.DoctorHasAppointment(Doctor, StartDate, EndDate);
        }
        public List<Appointment> ReadByPatientId(int patientId)
        {
            return AppointmentService.ReadByPatientId(patientId);
        }

        public List<Appointment> ReadRecommendation(Patient patient, int doctorId, DateTime start, DateTime end)
        {
            return AppointmentService.ReadRecommendation(doctorId, start, end, patient);
        }
    }
}