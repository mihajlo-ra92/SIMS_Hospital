using Dto;
using FileHandler;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class MedicineRepository
    {
        public MedicineFileHandler MedicineFileHandler = new MedicineFileHandler();
        public List<Medicine> medicines { get; set; }
        public MedicineRepository()
        {
            medicines = MedicineFileHandler.Read();
        }
        public List<Medicine> ReadAll()
        {
            return medicines;
        }
        public Medicine ReadById(int medicineId)
        {
            return medicines.Where(x => x.Id == medicineId).FirstOrDefault();
        }
        public void MakeNotValid(int medicineId, string note)
        {
            Medicine SelectedMedicine = ReadById(medicineId);
            InvalidateMedicine(SelectedMedicine, note);
            MedicineFileHandler.Write(medicines);
        }
        private void InvalidateMedicine(Medicine SelectedMedicine, string note)
        {
            SelectedMedicine.IsValid = false;
            SelectedMedicine.Note = note;

        }
    }
}
