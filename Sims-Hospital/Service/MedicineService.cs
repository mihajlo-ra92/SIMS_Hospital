using Dto;
using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class MedicineService
    {
        MedicineRepository MedicineRepository;
        public MedicineService(MedicineRepository medicineRepository)
        {
            MedicineRepository = medicineRepository;
        }
        public List<Medicine> ReadAll()
        {
            return MedicineRepository.ReadAll();
        }
        public Medicine ReadById(int medicineId)
        {
            return MedicineRepository.ReadById(medicineId);
        }
        public void MakeNotValid(int medicineId, string note)
        {
            MedicineRepository.MakeNotValid(medicineId, note);
        }
    }
}
