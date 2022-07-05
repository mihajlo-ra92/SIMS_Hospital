// File:    SpecialistFileHandler.cs
// Author:  stani
// Created: Sunday, 3 April 2022 18:46:15
// Purpose: Definition of Class SpecialistFileHandler

using Model;
using Sims_Hospital;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace FileHandler
{
    public class SpecialistFileHandler
    {
        private string path = App.GetProjectPath() + "\\Resources\\Data\\specialists.csv";
        private static char DELIMITER = ',';

        public List<Specialist> Read()
        {
            List<Specialist> specialists = new List<Specialist>();

            foreach (var line in File.ReadLines(path))
            {
                string[] csvValues = line.Split(DELIMITER);
                Specialist specialist = new Specialist();
                specialist.fromCSV(csvValues);
                specialists.Add(specialist);
            }
            return specialists;
        }

        public void Write(List<Specialist> specialists)
        {
            using StreamWriter streamWriter = new StreamWriter(path);

            foreach (ISerializable specialist in specialists)
            {
                string line = string.Join(DELIMITER, specialist.toCSV());
                streamWriter.WriteLine(line);
            }
        }

    }
}