// File:    PatientFileHandler.cs
// Author:  stani
// Created: Sunday, 3 April 2022 18:44:09
// Purpose: Definition of Class PatientFileHandler

using Model;
using Sims_Hospital;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace FileHandler
{
    public class PatientFileHandler
    {
        private string path = App.GetProjectPath() + "\\Resources\\Data\\patients.csv";
        private static char DELIMITER = ',';

        public List<Patient> Read()
        {
            List<Patient> patients = new List<Patient>();

            foreach (var line in File.ReadLines(path))
            {
                if (line != "")
                {
                    string[] csvValues = line.Split(DELIMITER);
                    Patient patient = new Patient();
                    patient.fromCSV(csvValues);
                    patients.Add(patient);
                }
            }
            return patients;
        }

        public void Write(List<Patient> patients)
        {
            using StreamWriter streamWriter = new StreamWriter(path);

            foreach (ISerializable patient in patients)
            {
                string line = string.Join(DELIMITER, patient.toCSV());
                streamWriter.WriteLine(line);
            }
        }

    }
}