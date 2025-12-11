using Icarus_Drone_Service_Application.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Icarus_Drone_Service_Application.Resources
{
    public class TwoDecimalValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (string.IsNullOrWhiteSpace((string)value))
            {
                return new ValidationResult(false, "Service cost cannot be empty.");
            }
            if (!Utils.IsDecimalWithinPlaceLimit((string)value, 2))
            {
                return new ValidationResult(false, "Invalid input, expecting a numerical input with 2 decimal places.");
            }
            if (!double.TryParse((string)value, out double result))
            {
                return new ValidationResult(false, "Parsing input failed, expecting a numerical input with 2 decimal places.");
            }

            return ValidationResult.ValidResult;
        }
    }
}
