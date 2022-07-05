using Model;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for Address.xaml
    /// </summary>
    public partial class AddressDialog : Window
    {
        public Address PatientAddress { get; }

        public AddressDialog(Address patientAddress)
        {
            InitializeComponent();
            PatientAddress = patientAddress;
        }

        private void SaveAddressButton_Click(object sender, RoutedEventArgs e)
        {
            PatientAddress.Street = streetText.Text;
            PatientAddress.StreetNumber = numberText.Text;
            PatientAddress.City = cityText.Text;
            PatientAddress.Country = countryText.Text;

            this.Close();
        }
    }
}
