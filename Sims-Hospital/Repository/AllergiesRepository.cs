using Dto;
using DTO;
using FileHandler;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AllergiesRepository
    {
        private List<PatientAllergies> allergies;
        public AllergiesFileHandler allergiesFileHandler;

        public AllergiesRepository(AllergiesFileHandler allergiesFileHandler)
        {
            this.allergiesFileHandler = allergiesFileHandler;
            allergies = allergiesFileHandler.Read();
        }


        public List<PatientAllergies> ReadAll()
        {
            return allergies;
        }

        public PatientAllergies ReadByPatientId(int patientId)
        {
            return allergies.Where(x => x.Patient.Id == patientId).FirstOrDefault();
        }

        public void Create(CreateAllergiesDTO newAllergies)
        {
            int id = 0;
            if (allergies.Count > 0)
            {
                id = allergies.Max(x => x.Id) + 1;
            }

            PatientAllergies patientAllergies = new PatientAllergies()
            {
                Id = id,
                Allergens = newAllergies.Allergens,
                Medicines = newAllergies.Medicines,
                Patient = newAllergies.Patient
            };

            allergies.Add(patientAllergies);

            allergiesFileHandler.Write(allergies);
        }

        public void Edit(EditAllergiesDTO editAllergies)
        {
            allergiesFileHandler.Write(allergies);
    }

        public void Delete(int patientId)
        {
            PatientAllergies patientAllergies = allergies.Where(x => x.Patient.Id == patientId).First();
            allergies.Remove(patientAllergies);

            allergiesFileHandler.Write(allergies);
        }

    }
}
