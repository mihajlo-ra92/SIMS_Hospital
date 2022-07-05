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
    public class MedicineController
    {
        public MedicineService MedicineService;
        public MedicineController(MedicineService MedicineService)
        {
            this.MedicineService = MedicineService;
        }
        public List<Medicine> ReadAll()
        {
            return MedicineService.ReadAll();
        }
        public Medicine ReadById(int medicineId)
        {
            return MedicineService.ReadById(medicineId);
        }
        public void MakeNotValid(int medicineId, string note)
        {
            MedicineService.MakeNotValid(medicineId, note);
        }
    }
}
