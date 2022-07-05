using Dto;
using DTO;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class AllergiesController
    {
        public AllergiesService allergiesService;

        public AllergiesController(AllergiesService allergiesService)
        {
            this.allergiesService = allergiesService;
        }

        public List<PatientAllergies> ReadAll()
        {
            return allergiesService.ReadAll();  
        }
        public PatientAllergies ReadByPatientId(int id)
        {
            return allergiesService.ReadByPatientId(id);
        }

        public PatientAllergies ReadById(int patientId)
        {
            return allergiesService.ReadByPatientId(patientId);
        }
        public List<string> PrintById(int patiendId)
        {
            return allergiesService.PrintById(patiendId);
        }
        public List<string> ReadAllergicMedicineNamesById(int patientId)
        {
            return allergiesService.ReadAllergicMedicineNamesById(patientId);
        }

        public void Create(CreateAllergiesDTO newAllergies)
        {
            allergiesService.Create(newAllergies);
        }

        public void Edit(EditAllergiesDTO editAllergies)
        {
            allergiesService.Edit(editAllergies);
        }

        public void Delete(int allergiesId)
        {
            allergiesService.Delete(allergiesId);
        }

    }
}
