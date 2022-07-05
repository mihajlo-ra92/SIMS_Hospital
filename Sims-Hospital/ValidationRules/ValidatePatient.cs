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
    internal class ValidatePatient : ValidationRule
    {
        public UserController UserController;
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var app = Application.Current as App;
            UserController = app.UserController;
            if (UserController.UsernameExists(value.ToString()) & UserController.UserIsPatient(value.ToString()))
            {
                return ValidationResult.ValidResult;
            }
            if (UserController.UsernameExists(value.ToString()))
            {
                return new ValidationResult(false, "User is not patient.");
            }
            return new ValidationResult(false, "Patient not found.");
        }
    }
}
