// File:    AppointmentService.cs
// Author:  stani
// Created: Monday, 28 March 2022 19:33:04
// Purpose: Definition of Class AppointmentService

using Dto;
using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class AppointmentService
    {
        public AppointmentRepository appointmentRepository;
        public AppointmentScheduleRepository appointmentScheduleRepository;
        public RoomRepository roomRepository;
        public DoctorRepository doctorRepository;
        public PatientRepository patientRepository;
        public ReportRepository reportRepository;
        public PrescriptionRepository prescriptionRepository;

        public AppointmentService(AppointmentRepository appointmentRepository, RoomRepository roomRepository, 
            DoctorRepository doctorRepository, PatientRepository patientRepository,
            ReportRepository reportRepository, PrescriptionRepository prescriptionRepository,
            AppointmentScheduleRepository appointmentScheduleRepository)
        {
            this.appointmentRepository = appointmentRepository;
            this.roomRepository = roomRepository;
            this.doctorRepository = doctorRepository;
            this.patientRepository = patientRepository;
            this.reportRepository = reportRepository;
            this.prescriptionRepository = prescriptionRepository;
            this.appointmentScheduleRepository = appointmentScheduleRepository;
            ReadAll();
        }

        public void Create(CreateAppointmentDTO newAppointment)
        {
            appointmentRepository.Create(newAppointment);
        }

        internal void EditByPatient(EditAppointmentPatientDTO editAppointmentPatientDTO)
        {
            List<Room> rooms = roomRepository.ReadAll();
            List<Appointment> appointments = appointmentRepository.ReadAll();
            foreach (Room roomItem in rooms)
            {
                if (roomItem.RoomType == "CheckUp")
                {
                    bool isFree = true;
                    foreach (Appointment appointment in appointments)
                    {
                        if (DateTime.Compare(appointment.StartTime.AddMinutes(-20), editAppointmentPatientDTO.StartTime) > 0 && DateTime.Compare(appointment.StartTime.AddMinutes(20), editAppointmentPatientDTO.StartTime) < 0)
                        {
                            isFree = false;
                        }
                    }
                    if (isFree == true)
                    {
                        appointmentRepository.EditByPatient(editAppointmentPatientDTO, roomItem);
                        break;
                    }
                }
            }
        }

        public void CreateByPatient(CreateAppointmentPatientDTO CreateAppointmentPatientDTO)
        {
            List<Room> rooms = roomRepository.ReadAll();
            List<Appointment> appointments = appointmentRepository.ReadAll(); 
            foreach(Room roomItem in rooms)
            {
                if(roomItem.RoomType == "CheckUp")
                {
                    bool isFree = true;
                    foreach(Appointment appointment in appointments)
                    {
                        if(DateTime.Compare(appointment.StartTime.AddMinutes(-20), CreateAppointmentPatientDTO.StartTime) > 0 && DateTime.Compare(appointment.StartTime.AddMinutes(20), CreateAppointmentPatientDTO.StartTime) < 0)
                        {
                            isFree = false;
                        }
                    }
                    if(isFree == true)
                    {
                        appointmentRepository.CreateByPatient(CreateAppointmentPatientDTO, roomItem);
                        break;
                    }
                }
            }

        }
        public List<Appointment> ReadAll()
        {
            var rooms = roomRepository.ReadAll();
            var doctors = doctorRepository.ReadAll();
            var patients = patientRepository.ReadAll();
            var appointments = appointmentRepository.ReadAll();
            BindRoomsWithAppointments(rooms, appointments);
            BindDoctorsWithAppointments(doctors, appointments);
            BindPatientsWithAppointments(patients, appointments);
            return appointmentRepository.ReadAll();
        }
        public void BindRoomsWithAppointments(IEnumerable<Room> rooms, IEnumerable<Appointment> appointments)
        {
            appointments.ToList().ForEach(appointment =>
            {
                appointment.Room = FindRoomById(rooms, appointment.Room.Id);
            });
        }


        private Room FindRoomById(IEnumerable<Room> rooms, int id)
        {
            return rooms.SingleOrDefault(room => room.Id == id);
        }

        public void BindDoctorsWithAppointments(IEnumerable<Doctor> doctors, IEnumerable<Appointment> appointments)
        {
            appointments.ToList().ForEach(appointment =>
            {
                appointment.Doctor = FindDoctorById(doctors, appointment.Doctor.Id);
            });
        }


        private Doctor FindDoctorById(IEnumerable<Doctor> doctors, int id)
        {
            return doctors.SingleOrDefault(doctor => doctor.Id == id);
        }
        
        public void BindPatientsWithAppointments(IEnumerable<Patient> patients, IEnumerable<Appointment> appointments)
        {
            appointments.ToList().ForEach(appointment =>
            {
                appointment.Patient = FindPatientById(patients, appointment.Patient.Id);
            });
        }


        private Patient FindPatientById(IEnumerable<Patient> patients, int id)
        {
            return patients.SingleOrDefault(patient => patient.Id == id);
        }

        public Appointment ReadById(int appointmentId)
        {
            return appointmentRepository.ReadById(appointmentId);
        }
        public List<Appointment> ReadByDoctorId(int doctorId)
        {
            var rooms = roomRepository.ReadAll();
            var doctors = doctorRepository.ReadAll();
            var patients = patientRepository.ReadAll();
            var appointments = appointmentRepository.ReadAll();
            BindRoomsWithAppointments(rooms, appointments);
            BindDoctorsWithAppointments(doctors, appointments);
            BindPatientsWithAppointments(patients, appointments);
            return appointmentRepository.ReadByDoctorId(doctorId);
        }
        public List<Appointment> ReadbyDoctorIdAndStartDate(int doctorId, DateTime date)
        {
            var rooms = roomRepository.ReadAll();
            var doctors = doctorRepository.ReadAll();
            var patients = patientRepository.ReadAll();
            var appointments = appointmentRepository.ReadAll();
            BindRoomsWithAppointments(rooms, appointments);
            BindDoctorsWithAppointments(doctors, appointments);
            BindPatientsWithAppointments(patients, appointments);
            return appointmentRepository.ReadByDoctorIdAndStartDate(doctorId, date);
        }

        public List<Appointment> ReadByStartDate(DateTime date)
        {
            var rooms = roomRepository.ReadAll();
            var doctors = doctorRepository.ReadAll();
            var patients = patientRepository.ReadAll();
            var appointments = appointmentRepository.ReadAll();
            BindRoomsWithAppointments(rooms, appointments);
            BindDoctorsWithAppointments(doctors, appointments);
            BindPatientsWithAppointments(patients, appointments);
            return appointmentRepository.ReadByStartDate(date);
        }
        public void Edit(EditAppointmentDTO editAppointment)
        {
            appointmentRepository.Edit(editAppointment);
        }

        public void Delete(int appointmentId)
        {
            appointmentRepository.Delete(appointmentId);
            reportRepository.DeleteByAppointmentId(appointmentId);
            prescriptionRepository.DeleteByAppointmentId(appointmentId);
        }

        public bool IsRoomFree(int roomId, DateTime startTime, DateTime endTime, int appointmentId = -1)
        {
            return appointmentScheduleRepository.IsRoomFree(roomId, startTime, endTime, appointmentId);
        }

        public bool IsDoctorFree(int doctorId, DateTime startTime, DateTime endTime, int appointmentId = -1)
        {
            return appointmentScheduleRepository.IsDoctorFree(doctorId, startTime, endTime, appointmentId);
        }

        public bool IsPatientFree(int patientId, DateTime startTime, DateTime endTime, int appointmentId = -1)
        {
            return appointmentScheduleRepository.IsPatientFree(patientId, startTime, endTime, appointmentId);
        }

        //public void StartAppointment(Appointment appointment)
        //{
        //    throw new NotImplementedException();
        //}

        //public void EndAppointment(Appointment appointment)
        //{
        //    throw new NotImplementedException();
        //}
        public bool DoctorHasAppointment(Doctor Doctor, DateTime StartDate, DateTime EndDate)
        {
            List<Appointment> appointments = ReadByDoctorId(Doctor.Id);
            foreach (Appointment appointment in appointments)
            {   //checks if two appointment time span overlaps with given time span
                if (appointment.StartTime.Date < EndDate.Date && StartDate.Date < appointment.EndTime.Date)
                {
                    return true;
                }
            }
            return false;
        }
        public List<Appointment> ReadByPatientId(int patientId)
        {
            return appointmentRepository.ReadByPatientId(patientId);
        }

        private DateTime MakeTime(DateTime dateTime, int hours, int minutes)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, hours, minutes, 0);
        }

        public List<Appointment> ReadRecommendation(int doctorId,DateTime start,DateTime end, Patient patient)
        {
            var doctors = doctorRepository.ReadAll();
            var appointments = appointmentRepository.ReadAll();
            BindDoctorsWithAppointments(doctors, appointments);
            DateTime end1 = end;
            DateTime Start = start.AddHours(8);
            List<Appointment> appointmentListDoctor = appointmentRepository.ReadFromDateToDate(start, end);
            List<Appointment> appointmentList = new List<Appointment>();
            DateTime End = end1.AddHours(-2);
            while (DateTime.Compare(Start, End) < 0)
            { 
               Appointment appointment = null;
                bool isFree = true;
                foreach(Appointment item in appointmentListDoctor)
                {
                    int res1 = DateTime.Compare(item.StartTime.AddMinutes(-20), Start);
                    int res2 = DateTime.Compare(item.EndTime, Start);
                    if (res1 < 0 && res2 > 0) 
                    {
                        isFree = false;
                    }
                }
                if (isFree == true)
                {
                    appointment = new Appointment(patient, doctorRepository.ReadById(doctorId), Start, Start.AddMinutes(20));
                    appointmentList.Add(appointment);
                }
                Start = Start.AddMinutes(20);
                if(Start.Hour >= 22)
                {
                    Start = MakeTime(Start.AddDays(1),8,0);
                    
                }
                else if(Start.Hour < 8)
                {
                    Start = MakeTime(Start,8,0);
                }
            }
            return appointmentList;
        }
    }
}