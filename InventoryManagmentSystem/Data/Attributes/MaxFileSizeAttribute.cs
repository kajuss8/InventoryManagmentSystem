﻿using System.ComponentModel.DataAnnotations;

namespace InventoryManagmentSystem.Data.Attributes
{
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int _maxFileSize;
        public MaxFileSizeAttribute(int maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                if (file.Length > _maxFileSize)
                {
                    return new ValidationResult($"File is too big. Maximum size is {_maxFileSize}");
                }
            }
            return ValidationResult.Success;
        }
    }
}
