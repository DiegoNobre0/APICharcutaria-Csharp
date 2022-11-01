using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CharcutariaAPI.Validation
{
    public class ValidationCPF : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return base.IsValid(value, validationContext);
            }

            Regex RegexCPF = new Regex("^[0-9]{3}[.][0-9]{3}[.][0-9]{3}[-][0-9]{2}$");


            if (!RegexCPF.IsMatch(value.ToString()))
            {
                return new ValidationResult("O CPF deve ter um formato válido");
            }

            return ValidationResult.Success;
        }
    }
}
