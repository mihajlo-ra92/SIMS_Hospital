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
    internal class ValidateUser : ValidationRule
    {
        public UserController UserController;
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var app = Application.Current as App;
            UserController = app.UserController;
            if (UserController.UsernameExists(value.ToString()))
            {
                return ValidationResult.ValidResult;
            }
            return new ValidationResult(false, "User not found.");
        }
    }
}
