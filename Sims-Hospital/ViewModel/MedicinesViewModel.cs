using Controller;
using Sims_Hospital;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace Model
{
    public class MedicinesViewModel : BindableBase
    {
        private MedicineController MedicineController;
        public ObservableCollection<Medicine> Medicines { get; set; }
        public Medicine selectedMedicine;
        public ObservableCollection<string> Ingredients { get; set; }
        public ObservableCollection<string> ingredients { get; set; }
        public string note { get; set; }

        public string Note
        {
            get { return note; }
            set
            {
                if (note != value)
                {
                    note = value;
                    OnPropertyChanged("Note");
                }
            }
        }
        public Medicine SelectedMedicine
        {
            get { return selectedMedicine; }
            set
            {
                selectedMedicine = value;
                SelectedMedicineChanged();
            }
        }
        public MedicinesViewModel()
        {
            LoadMedicines();
        }
        public void LoadMedicines()
        {
            var app = Application.Current as App;
            MedicineController = app.MedicineController;
            ObservableCollection<Medicine> medicines = new ObservableCollection<Medicine>();

            ingredients = new ObservableCollection<string>();
            ingredients.Add("---");
            Ingredients = ingredients;
            foreach (Medicine medicineIt in MedicineController.ReadAll())
            {
                medicines.Add(medicineIt);
            }
            Medicines = medicines;
        }
        public void SelectedMedicineChanged()
        {
            if (SelectedMedicine != null)
            {
                LoadFields();
            }
        }
        public void LoadFields()
        {
            Note = selectedMedicine.Note;
            ingredients.Clear();
            foreach(string ingredientIt in selectedMedicine.Ingredients)
            {
                ingredients.Add(ingredientIt);
            }
            Ingredients = ingredients;
        }
    }
}
