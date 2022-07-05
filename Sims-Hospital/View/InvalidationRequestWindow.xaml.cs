using Controller;
using Dto;
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
    /// Interaction logic for InvalidationRequestWindow.xaml
    /// </summary>
    public partial class InvalidationRequestWindow : Window
    {
        public Medicine Medicine;
        public InvalidationRequestController InvalidationRequestController;
        public InvalidationRequestWindow(Medicine medicine)
        {
            InitializeComponent();
            this.Medicine = medicine;
            var app = Application.Current as App;
            InvalidationRequestController = app.InvalidationRequestController;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateRequest();
            this.Close();
        }
        private void CreateRequest()
        {
            CreateInvalidationRequestDTO requestDTO = new CreateInvalidationRequestDTO();
            requestDTO.Note = invalidationNote.Text;
            requestDTO.Medicine = Medicine;
            requestDTO.RequestState = RequestStateType.Waiting;
            InvalidationRequestController.Create(requestDTO);
        }
    }
}
