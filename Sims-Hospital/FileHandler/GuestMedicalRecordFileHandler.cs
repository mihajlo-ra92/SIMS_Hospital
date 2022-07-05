// File:    GuestMedicalRecordFileHandler.cs
// Author:  stani
// Created: Sunday, 3 April 2022 18:46:15
// Purpose: Definition of Class GuestMedicalRecordFileHandler

using Model;
using Sims_Hospital;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace FileHandler
{
    public class GuestMedicalRecordFileHandler
    {
        private string path = App.GetProjectPath() + "\\Resources\\Data\\guest.csv";
        private static char DELIMITER = ',';

        public List<GuestMedicalRecord> Read()
        {
            List<GuestMedicalRecord> medicalRecords = new List<GuestMedicalRecord>();

            foreach (string line in File.ReadLines(path))
            {
                string[] csvValues = line.Split(DELIMITER);
                GuestMedicalRecord medical = new();
                medical.fromCSV(csvValues);
                medicalRecords.Add(medical);
            }

            return medicalRecords;
        }

        public void Write(List<GuestMedicalRecord> medicalRecords)
        {
            using StreamWriter streamWriter = new StreamWriter(path);

            foreach (ISerializable medical in medicalRecords)
            {
                string line = string.Join(DELIMITER, medical.toCSV());
                streamWriter.WriteLine(line);
            }
        }

    }
}