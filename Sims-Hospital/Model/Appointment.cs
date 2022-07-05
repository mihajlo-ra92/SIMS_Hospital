// File:    Appointment.cs
// Author:  stani
// Created: Monday, 28 March 2022 19:47:14
// Purpose: Definition of Class Appointment

using Controller;
using Sims_Hospital;
using Sims_Hospital.Utils;
using System;
using System.Windows;

namespace Model
{
    public class Appointment : ISerializable
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public AppointmentType Purpose { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public Room Room { get; set; }

        public String AppointmentStartDate
        {
            get
            {
                return StartTime.ToString("dd/MM/yyyy");
            }
        }
        public String AppointmentStartTime
        {
            get
            {
                return StartTime.ToString("HH:mm");
            }
        }
        public String AppointmentEndTime
        {
            get
            {
                return EndTime.ToString("HH:mm");
            }
        }
        public Appointment()
        {
        }
        //added for report
        public Appointment(int id)
        {
            Id = id;
        }
        public Appointment(Patient patient, Doctor doctor, DateTime startTime, DateTime endTime)
        {
            Patient = patient;
            Doctor = doctor;
            StartTime = startTime;
            EndTime = endTime;
        }

        public void fromCSV(string[] values)
        {
            if (values[0] != "")
            {
                Id = int.Parse(values[0]);
                //StartTime = DateTime.Parse(values[1]);
                StartTime = DateTime.ParseExact(values[1], "dd/MM/yyyy HH:mm:ss", null);
                //EndTime = DateTime.Parse(values[2]);
                EndTime = DateTime.ParseExact(values[2], "dd/MM/yyyy HH:mm:ss", null);
                Purpose = (AppointmentType)Enum.Parse(typeof(AppointmentType), values[3]);
                Doctor = new Doctor(int.Parse(values[4]));
                Room = new Room(int.Parse(values[5]));
                Patient = new Patient(int.Parse(values[6]));
            }
        }

        public string[] toCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                DateUtils.DateToString(StartTime),
                DateUtils.DateToString(EndTime),
                Purpose.ToString(),
                Doctor.Id.ToString(),
                Room.Id.ToString(),
                Patient.Id.ToString(),
            };
            return csvValues;
        }
    }
}