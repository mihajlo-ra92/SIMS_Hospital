using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Sims_Hospital.ValidationRules
{
    internal class ValidateMinute : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            foreach(char c in value.ToString())
            {
                if (c < '0' || c > '9')
                    return new ValidationResult(false, "Text is not a number.");
            }
            if (value.ToString() != "")
            {
                int number = Int32.Parse(value.ToString());
                if (number < 0 || number > 59)
                {
                    return new ValidationResult(false, "Minute must be between 0 and 60");
                }
            }
            return ValidationResult.ValidResult;
        }
    }
}
