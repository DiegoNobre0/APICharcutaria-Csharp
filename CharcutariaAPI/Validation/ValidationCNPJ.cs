using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CharcutariaAPI.Validation
{
    public class ValidationCNPJ : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return base.IsValid(value, validationContext);
            }

            Regex RegexCNPJ = new Regex("^[0-9]{2}[.][0-9]{3}[.][0-9]{3}[/][0-9]{4}[-][0-9]{2}$");


            if (!RegexCNPJ.IsMatch(value.ToString()))
            {
                return new ValidationResult("O CNPJ deve ter um formato válido");
            }

            return ValidationResult.Success;
        }
    }
}
