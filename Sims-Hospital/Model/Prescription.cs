using Controller;
using Sims_Hospital;
using Sims_Hospital.Utils;
using System;
using System.Windows;

namespace Model
{
    public class Prescription : ISerializable
    {
        public int Id { get; set; }
        public Appointment Appointment  { get; set; }
        public Patient Patient { get; set; }
        public string Medicine { get; set; }
        public int Ammount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TimesADay { get; set; }

        public Prescription()
        {
        }
        public Prescription(int id)
        {
            Id = id;
        }
        public void fromCSV(string[] values)
        {
            if (values[0] != "")
            {
                Id = int.Parse(values[0]);
                Appointment = new Appointment(int.Parse(values[1]));
                Patient = new Patient(int.Parse(values[2]));
                Medicine = values[3];
                Ammount = int.Parse(values[4]);
                //StartDate = DateTime.Parse(values[5]);
                StartDate = DateTime.ParseExact(values[5], "dd/MM/yyyy HH:mm:ss", null);
                //EndDate = DateTime.Parse(values[6]);
                EndDate = DateTime.ParseExact(values[6], "dd/MM/yyyy HH:mm:ss", null);
                TimesADay = int.Parse(values[7]);
            }
        }

        public string[] toCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                Appointment.Id.ToString(),
                Patient.Id.ToString(),
                Medicine.ToString(),
                Ammount.ToString(),
                DateUtils.DateToString(StartDate),
                DateUtils.DateToString(EndDate),
                TimesADay.ToString(),
            };
            return csvValues;
        }
    }
}
