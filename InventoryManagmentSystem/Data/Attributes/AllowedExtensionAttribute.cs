using System.ComponentModel.DataAnnotations;

namespace InventoryManagmentSystem.Data.Attributes
{
    public class AllowedExtensionAttribute : ValidationAttribute
    {
        private readonly string[] _allowedExtension;
        public AllowedExtensionAttribute(string[] allowedExtension)
        {
            _allowedExtension = allowedExtension;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                var extension = Path.GetExtension(file.FileName);
                if (!_allowedExtension.Contains(extension))
                {
                    return new ValidationResult("This file extension isn't supported");
                }
            }

            return ValidationResult.Success;
        }
    }
}
