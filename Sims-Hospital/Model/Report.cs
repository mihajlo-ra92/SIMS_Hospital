using Controller;
using Sims_Hospital;
using System;
using System.Windows;

namespace Model
{
    public class Report : ISerializable
    {
        public int Id { get; set; }
        public Appointment Appointment { get; set; }
        public string Content { get; set; }
        public Report()
        {
        }
        public Report(int id)
        {
            Id = id;
        }
        public void fromCSV(string[] values)
        {
            if (values[0] != "")
            {
                Id = int.Parse(values[0]);
                Appointment = new Appointment(int.Parse(values[1]));
                Content = values[2];

            }
        }

        public string[] toCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                Appointment.Id.ToString(),
                Content.ToString(),
            };
            return csvValues;
        }
    }
}
