// File:    AppointmentFileHandler.cs
// Author:  stani
// Created: Monday, 28 March 2022 19:22:31
// Purpose: Definition of Class AppointmentFileHandler

using Model;
using Sims_Hospital;
using System;
using System.Collections.Generic;
using System.IO;

namespace FileHandler
{

    public class AppointmentFileHandler
    {
        private string path = App.GetProjectPath() + "\\Resources\\Data\\appointments.csv";
        private static char DELIMITER = ',';

        public List<Appointment> Read()
        {
            List<Appointment> appointments = new List<Appointment>();

            foreach (var line in File.ReadLines(path))
            {
                if (line != "")
                {
                    string[] csvValues = line.Split(DELIMITER);
                    Appointment appointment = new Appointment();
                    appointment.fromCSV(csvValues);
                    appointments.Add(appointment);
                }
            }
            return appointments;
        }

        public void Write(List<Appointment> appointments)
        {
            using StreamWriter streamWriter = new StreamWriter(path);
            foreach (ISerializable appointment in appointments)
            {
                string line = string.Join(DELIMITER, appointment.toCSV());
                streamWriter.WriteLine(line);
            }
        }

    }
}
