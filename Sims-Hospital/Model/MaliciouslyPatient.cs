using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sims_Hospital.Utils;
using System.Threading.Tasks;

namespace Model
{
    public class MaliciouslyPatient : ISerializable
    {
        public Patient Patient { get; set; }
        public DateTime EditTime { get; set; }

        public MaliciouslyPatient()
        {

        }
        public MaliciouslyPatient(Patient patient , DateTime time)
        {
            Patient = patient;
            EditTime = time;
        }
        public void fromCSV(string[] values)
        {
            Patient = new Patient(int.Parse(values[0]));
            EditTime = DateTime.ParseExact(values[1], "dd/MM/yyyy HH:mm:ss", null);
        }

        public string[] toCSV()
        {
            string[] csvValues =
            {
            Patient.Id.ToString(),
            DateUtils.DateToString(EditTime)
            };
            return csvValues;
        }
    }
}
