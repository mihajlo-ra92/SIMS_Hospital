using Controller;
using Dto;
using DTO;
using Model;
using System;
using System.Collections.Generic;
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

    public partial class Allergies : Window
    {
        public BindingList<string> AllergiesBinding { get; }
        public CreateAllergiesDTO CreateAllergiesDTO { get; }
        public bool IsEdit { get; }
        public AllergiesController AllergiesController{ get; set; }

        public Allergies(CreateAllergiesDTO createAllergiesDTO, bool isEdit)
        {
            InitializeComponent();

            CreateAllergiesDTO = createAllergiesDTO;
            IsEdit = isEdit;
            AllergiesBinding = new BindingList<string>(CreateAllergiesDTO.Allergens);
            allergiesList.ItemsSource = AllergiesBinding;

            var app = Application.Current as App;
            AllergiesController = app.AllergiesController;
        }

        private void AddAllergie_Click(object sender, RoutedEventArgs e)
        {
            CreateAllergiesDTO.Allergens.Add(allergieText.Text);
            AllergiesBinding.ResetBindings();
            allergieText.Text = "";
        }

        private void AddMedicine_Click(object sender, RoutedEventArgs e)
        {
            AddMedicineAllergy addMedicineAllergy = new AddMedicineAllergy(CreateAllergiesDTO);
            addMedicineAllergy.Show();
        }

        private void DeleteAllergie_Click(object sender, RoutedEventArgs e)
        {
            CreateAllergiesDTO.Allergens.Remove((string)allergiesList.SelectedItem);
            AllergiesBinding.ResetBindings();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (IsEdit == false)
            {
                AllergiesController.Create(CreateAllergiesDTO);
            }else
            {
                AllergiesController.Edit((EditAllergiesDTO)CreateAllergiesDTO);
            }
        }
    }
}
