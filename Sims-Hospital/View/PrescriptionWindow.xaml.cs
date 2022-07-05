using Controller;
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
    /// <summary>
    /// Interaction logic for PrescriptionWindow.xaml
    /// </summary>
    public partial class PrescriptionWindow : Window, INotifyPropertyChanged
    {
        private Appointment Appointment;
        private Prescription Prescription;
        private PrescriptionController prescriptionController;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private string _medicineName;
        public string MedicineName
        {
            get
            {
                return _medicineName;
            }
            set
            {
                if (_medicineName != value)
                {
                    _medicineName = value;
                    OnPropertyChanged("MedicineName");
                }
            }
        }
        public PrescriptionWindow(Appointment appointment)
        {
            InitializeComponent();
            this.DataContext = this;
            this.Appointment = appointment;
            var app = Application.Current as App;
            this.prescriptionController = app.PrescriptionController;
            if (prescriptionController.AppointmentHasPrescription(this.Appointment.Id))
            {
                //this.Prescription = prescriptionController.ReadByAppointmentId(this.Appointment.Id);
            }
            else
            {
                this.Prescription = new Prescription();
                this.Prescription.Appointment = this.Appointment;
            }
            InitializeFields();
        }
        private void InitializeFields()
        {
            if (this.Prescription.Medicine == null)
            {
                medicineName.Text = "";
            }
            else
            {
                medicineName.Text = Prescription.Medicine;
            }
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            this.Prescription.Medicine = medicineName.Text;
            this.Prescription.Medicine = MedicineName;

            if (prescriptionController.AppointmentHasPrescription(this.Appointment.Id))
            {
            }
            else
            {

            }
        }
    }
}
