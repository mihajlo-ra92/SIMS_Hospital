// File:    MedicalRecordFileHandler.cs
// Author:  stani
// Created: Sunday, 3 April 2022 18:46:15
// Purpose: Definition of Class MedicalRecordFileHandler

using Model;
using Sims_Hospital;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace FileHandler
{
    public class MedicalRecordFileHandler
    {
        private string path = App.GetProjectPath() + "\\Resources\\Data\\medicalrecord.csv";
        private static char DELIMITER = ',';

        public List<MedicalRecord> Read()
        {
            List<MedicalRecord> medicalRecords = new List<MedicalRecord>();

            foreach (var line in File.ReadLines(path))
            {
                string[] csvValues = line.Split(DELIMITER);
                MedicalRecord medicalRecord = new MedicalRecord();
                medicalRecord.fromCSV(csvValues);
                medicalRecords.Add(medicalRecord);
            }
            return medicalRecords;
        }

        public void Write(List<MedicalRecord> medicalRecords)
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