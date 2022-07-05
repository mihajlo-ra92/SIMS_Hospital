using Model;
using Sims_Hospital;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHandler
{
    public class MaliciouslyPatientFileHandler
    {
        private string path = App.GetProjectPath() + "\\Resources\\Data\\maliciouslyPatients.csv";
        private static char DELIMITER = ',';


        public List<MaliciouslyPatient> Read()
        {
            List<MaliciouslyPatient> patients = new List<MaliciouslyPatient>();

            foreach (var line in File.ReadLines(path))
            {
                if (line != "")
                {
                    string[] csvValues = line.Split(DELIMITER);
                    MaliciouslyPatient patient = new MaliciouslyPatient();
                    patient.fromCSV(csvValues);
                    patients.Add(patient);
                }
            }
            return patients;
        }

        public void Write(List<MaliciouslyPatient> patients)
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
