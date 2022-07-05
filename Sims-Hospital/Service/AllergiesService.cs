using Dto;
using DTO;
using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class AllergiesService
    {
        public AllergiesRepository allergiesRepository;
        public MedicineRepository medicineRepository;

        public AllergiesService(AllergiesRepository allergiesRepository, MedicineRepository medicineRepository)
        {
            this.allergiesRepository = allergiesRepository;
            this.medicineRepository = medicineRepository;
            ReadAll();
        }

        public List<PatientAllergies> ReadAll()
        {
            var medicines = medicineRepository.ReadAll();
            var allergies = allergiesRepository.ReadAll();
            BindMedicinesWithAllergies(medicines, allergies);
            return allergiesRepository.ReadAll();
        }
        public PatientAllergies ReadByPatientId(int id)
        {
            return allergiesRepository.ReadByPatientId(id);
        }
        public void BindMedicinesWithAllergies(List<Medicine> medicines, List<PatientAllergies> allergies)
        {
            //cant use foreach loop because its itarator values
            //are read only!!!
            for (int i = 0; i < allergies.Count; i++)
            {
                for (int j = 0; j < allergies[i].Medicines.Count; j++)
                {
                    allergies[i].Medicines[j] = FindMedicineById(medicines, allergies[i].Medicines[j].Id);
                }
            }
        }
        private Medicine FindMedicineById(IEnumerable<Medicine> medicines, int id)
        {
            return medicines.SingleOrDefault(medicine => medicine.Id == id);
        }

        public List<string> PrintById(int patientId)
        {
            List<string> retVal = new List<string>();
            PatientAllergies patientAllergies = ReadByPatientId(patientId);
            foreach (string allergen in patientAllergies.Allergens)
            {
                retVal.Add(allergen);
            }
            foreach (Medicine medicine in patientAllergies.Medicines)
            {
                retVal.Add(medicine.Name);
            }
            return retVal;

        }

        public void Create(CreateAllergiesDTO newAllergies)
        {
            allergiesRepository.Create(newAllergies);
        }

        public void Edit(EditAllergiesDTO editAllergies)
        {
            allergiesRepository.Edit(editAllergies);
        }

        public void Delete(int patientId)
        {
            allergiesRepository.Delete(patientId);
        }
        public List<string> ReadAllergicMedicineNamesById(int patientId)
        {
            var allergie = ReadByPatientId(patientId);
            List<string> names = new List<string>();
            foreach (Medicine medIt in allergie.Medicines)
            {
                names.Add(medIt.Name);
            }
            return names;

        }

    }
}
