using Model;
using Sims_Hospital;
using System;
using System.Collections.Generic;
using System.IO;

namespace FileHandler
{
    public class PrescriptionFileHandler
    {
        private string path = App.GetProjectPath() + "\\Resources\\Data\\prescriptions.csv";
        private static char DELIMITER = '|';

        public List<Prescription> Read()
        {
            List<Prescription> prescriptions= new List<Prescription>();
            foreach (var line in File.ReadLines(path))
            {
                if (line != "")
                {
                    string[] csvValues = line.Split(DELIMITER);
                    Prescription prescription = new Prescription();
                    prescription.fromCSV(csvValues);
                    prescriptions.Add(prescription);
                }
            }
            return prescriptions;
        }
        public void Write(List<Prescription> prescriptions)
        {
            using StreamWriter streamWriter = new StreamWriter(path);
            foreach (ISerializable prescription in prescriptions)
            {
                string line = string.Join(DELIMITER, prescription.toCSV());
                streamWriter.WriteLine(line);
            }
        }
    }
}
