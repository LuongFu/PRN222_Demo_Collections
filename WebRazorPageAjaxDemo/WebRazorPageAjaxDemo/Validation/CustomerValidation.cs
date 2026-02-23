using System.ComponentModel.DataAnnotations;

namespace WebRazorPageAjaxDemo.Validation
{
    public class CustomerValidation : ValidationAttribute
    {
        public CustomerValidation()
        {
            ErrorMessage = "The year of birth cannot greater than current year (2026)";
        }

        public override bool IsValid(object? value)
        {
            if (value == null)
            {
                return true;
            }
            if (int.TryParse(value.ToString(), out int year))
            {
                return year <= DateTime.Now.Year;
            }
            return false;
        }
    }
}
