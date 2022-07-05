using Model;
using Sims_Hospital;
using System;
using System.Collections.Generic;
using System.IO;

namespace FileHandler
{
    public class ReportFileHandler
    {
        private string path = App.GetProjectPath() + "\\Resources\\Data\\reports.csv";
        private static char DELIMITER = '|';

        public List<Report> Read()
        {
            List<Report> reports = new List<Report>();
            foreach (var line in File.ReadLines(path))
            {
                if (line != "")
                {
                    string[] csvValues = line.Split(DELIMITER);
                    Report report = new Report();
                    report.fromCSV(csvValues);
                    reports.Add(report);
                }
            }
            return reports;
        }
        public void Write(List<Report> reports)
        {
            using StreamWriter streamWriter = new StreamWriter(path);
            foreach (ISerializable report in reports)
            {
                string line = string.Join(DELIMITER, report.toCSV());
                streamWriter.WriteLine(line);
            }
        }
    }
}
