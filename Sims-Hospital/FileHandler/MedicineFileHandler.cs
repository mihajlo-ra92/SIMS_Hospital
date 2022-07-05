using Model;
using Sims_Hospital;
using System;
using System.Collections.Generic;
using System.IO;

namespace FileHandler
{
    public class MedicineFileHandler
    {
        private string path = App.GetProjectPath() + "\\Resources\\Data\\medicines.csv";
        private static char DELIMITER = '|';

        public List<Medicine> Read()
        {
            List<Medicine> medicines = new List<Medicine>();

            foreach (var line in File.ReadLines(path))
            {
                if (line != "")
                {
                    string[] csvValues = line.Split(DELIMITER);
                    Medicine medicine = new Medicine();
                    medicine.fromCSV(csvValues);
                    medicines.Add(medicine);
                }
            }
            return medicines;
        }

        public void Write(List<Medicine> medicines)
        {
            using StreamWriter streamWriter = new StreamWriter(path);
            foreach (ISerializable medicine in medicines)
            {
                string line = string.Join(DELIMITER, medicine.toCSV());
                streamWriter.WriteLine(line);
            }
        }
    }
}
