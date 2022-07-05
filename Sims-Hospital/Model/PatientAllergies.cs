using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PatientAllergies : ISerializable
    {
        public int Id { get; set; }
        public List<string> Allergens { get; set; }
        public List<Medicine> Medicines { get; set; }
        public Patient Patient { get; set; }
        
        public PatientAllergies()
        {

        }

        public PatientAllergies(int id)
        {
            Id = id;
        }

        public string[] toCSV()
        {
            string[] csvValues = 
            { 
                Id.ToString(),
                string.Join(';', Allergens.Select(x => x.ToString()).ToArray()),
                string.Join(';', Medicines.Select(x => x.Id.ToString()).ToArray()),
                Patient.Id.ToString(),
            };
            return csvValues;
        }

        public void fromCSV(string[] values)
        {
            if (values[0] != "")
            {
                Id = int.Parse(values[0]);
                Allergens = new List<string>(values[1].Split(';'));
                Medicines = new List<Medicine>();
                values[2].Split(';').ToList().ForEach(x => Medicines.Add(new Medicine(int.Parse(x))));
                Patient = new Patient(int.Parse(values[3]));
            }
        }
    }
}
