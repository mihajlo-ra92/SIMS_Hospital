using Model;
using Sims_Hospital;
using Sims_Hospital.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHandler
{
    public class AllergiesFileHandler
    {
        private string path = App.GetProjectPath() + "\\Resources\\Data\\allergies.csv";
        private static char DELIMITER = ',';

        public List<PatientAllergies> Read()
        {
            List<PatientAllergies> allergies = new List<PatientAllergies>();

            foreach (var line in File.ReadLines(path))
            {
                if (line != "")
                {
                    string[] csvValues = line.Split(DELIMITER);
                    PatientAllergies patientAllergies = new PatientAllergies();
                    patientAllergies.fromCSV(csvValues);
                    allergies.Add(patientAllergies);
                }
            }
            return allergies;
        }

        public void Write(List<PatientAllergies> patientsAllergies)
        {
            using StreamWriter streamWriter = new StreamWriter(path);

            foreach (ISerializable patientAllergies in patientsAllergies)
            {
                string line = string.Join(DELIMITER, patientAllergies.toCSV());
                streamWriter.WriteLine(line);
            }
        }

    }
}
