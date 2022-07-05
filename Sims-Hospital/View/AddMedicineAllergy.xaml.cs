using Dto;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Sims_Hospital.View
{
    /// <summary>
    /// Interaction logic for AddMedicineAllergy.xaml
    /// </summary>
    public partial class AddMedicineAllergy : Window
    {
        public List<Medicine> MedicinesData{ get; set; }
        public GuestMedicalRecord GuestMedicalRecord { get; }
        public ObservableCollection<Medicine> AddedMedicines { get; set; }
        public ObservableCollection<Medicine> RemainingMedicines { get; set; }
        public CreateAllergiesDTO CreateAllergiesDTO { get; }

        public AddMedicineAllergy(CreateAllergiesDTO createAllergiesDTO)
        {
            InitializeComponent();

            MedicinesData = new List<Medicine>() 
            {
                new Medicine(1, "E12", "Bromazepan"),
                new Medicine(2, "E13", "Aspirin"),
                new Medicine(3, "E14", "Lekadol")
            };
           
            CreateAllergiesDTO = createAllergiesDTO;
            
            BindMedicinesWithAllergies();

            AddedMedicines = new ObservableCollection<Medicine>(createAllergiesDTO.Medicines);

            RemainingMedicines = new ObservableCollection<Medicine>(FindRemainingMedicines());

            this.DataContext = this;
        }

        private void BindMedicinesWithAllergies()
        {
            CreateAllergiesDTO.Medicines.ForEach(m =>
            {
                FindAllergies(m);
            });
        }

        private void FindAllergies(Medicine m)
        {
            MedicinesData.ForEach(md =>
            {
                if (md.Id == m.Id)
                {
                    m.Code = md.Code;
                    m.Name = md.Name;
                }
            });
        }

        private List<Medicine> FindRemainingMedicines()
        {
            return MedicinesData.Where(m => !AddedMedicines.Any(am => am.Id == m.Id)).ToList();
        }

        private void AddMedicineButton_Click(object sender, RoutedEventArgs e)
        {
            Medicine selectedMedicine = (Medicine)dataGridMedicines.SelectedItem;
            
            AddedMedicines.Add(selectedMedicine);
            CreateAllergiesDTO.Medicines.Add(selectedMedicine);

            RemainingMedicines.Remove(selectedMedicine);
        }

        private void DeleteMedicineButton_Click(object sender, RoutedEventArgs e)
        {
            Medicine selectedMedicine = (Medicine)(dataGridAddedMedicines.SelectedItem);

            AddedMedicines.Remove(selectedMedicine);
            CreateAllergiesDTO.Medicines.Remove(selectedMedicine);

            RemainingMedicines.Add(selectedMedicine);
        }
    }
}
