using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CharcutariaAPI.Validation
{
    public class ValidationCelular : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return base.IsValid(value, validationContext);
            }

            Regex RegexCelular = new Regex("^[(][1-9]{2}[)][9][1-9]{1}[0-9]{3}[-][0-9]{4}$");


            if (!RegexCelular.IsMatch(value.ToString()))
            {
                return new ValidationResult("O número do celular deve ter um formato válido");
            }

            return ValidationResult.Success;
        }
    }
}
