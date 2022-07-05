using Controller;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Sims_Hospital.ValidationRules
{
    public class ValidateRoom : ValidationRule
    {
        public RoomController RoomController;
        public AppointmentController AppointmentController;
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var app = Application.Current as App;
            RoomController = app.RoomController;
            AppointmentController = app.AppointmentController;
            if (RoomController.RoomExists(value.ToString()))
            {
                return ValidationResult.ValidResult;
            }
            return new ValidationResult(false, "Room not found.");
        }
    }
}
