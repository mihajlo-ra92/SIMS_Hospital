// File:    DoctorFileHandler.cs
// Author:  stani
// Created: Sunday, 3 April 2022 18:46:15
// Purpose: Definition of Class DoctorFileHandler

using Model;
using Sims_Hospital;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace FileHandler
{
    public class DoctorFileHandler
    {
        private string path = App.GetProjectPath() + "\\Resources\\Data\\doctors.csv";
        private static char DELIMITER = ',';

        public List<Doctor> Read()
        {
            List<Doctor> doctors = new List<Doctor>();

            foreach (var line in File.ReadLines(path))
            {
                string[] csvValues = line.Split(DELIMITER);
                Doctor doctor = new Doctor();
                doctor.fromCSV(csvValues);
                doctors.Add(doctor);
            }
            return doctors;
        }

        public void Write(List<Doctor> doctors)
        {
            using StreamWriter streamWriter = new StreamWriter(path);

            foreach (ISerializable doctor in doctors)
            {
                string line = string.Join(DELIMITER, doctor.toCSV());
                streamWriter.WriteLine(line);
            }
        }

    }
}