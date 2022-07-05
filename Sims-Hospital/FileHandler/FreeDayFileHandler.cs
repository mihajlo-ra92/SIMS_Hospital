using Model;
using Sims_Hospital;
using System;
using System.Collections.Generic;
using System.IO;

namespace FileHandler
{
    public class FreeDayFileHandler
    {
        private string path = App.GetProjectPath() + "\\Resources\\Data\\freeDays.csv";
        private static char DELIMITER = '|';

        public List<FreeDay> Read()
        {
            List<FreeDay> freeDays = new List<FreeDay>();

            foreach (var line in File.ReadLines(path))
            {
                if (line != "")
                {
                    string[] csvValues = line.Split(DELIMITER);
                    FreeDay freeDay = new FreeDay();
                    freeDay.fromCSV(csvValues);
                    freeDays.Add(freeDay);
                }
            }
            return freeDays;
        }
        public void Write(List<FreeDay> freeDays)
        {
            using StreamWriter streamWriter = new StreamWriter(path);
            foreach (ISerializable freeDay in freeDays)
            {
                string line = string.Join(DELIMITER, freeDay.toCSV());
                streamWriter.WriteLine(line);
            }
        }
    }
}
