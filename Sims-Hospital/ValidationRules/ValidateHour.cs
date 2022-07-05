using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Sims_Hospital.ValidationRules
{
    internal class ValidateHour : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            foreach(char c in value.ToString())
            {
                if (c < '0' || c > '9')
                    return new ValidationResult(false, "Text is not a number.");
            }
            //if (value == null)
            //{
            //    return new ValidationResult(false, "Text is not a number.");
            //}
            if (value.ToString() != "")
            {
                int number = Int32.Parse(value.ToString());
                if (number < 0 || number > 23)
                {
                    return new ValidationResult(false, "Hour must be between 0 and 24");
                }
            }
            return ValidationResult.ValidResult;
        }
    }
}
