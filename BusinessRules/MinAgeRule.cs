using System;
using System.ComponentModel.DataAnnotations;
using Vidly2.Models;

namespace Vidly2.BusinessRules
{
    public class MinAgeRule : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer) validationContext.ObjectInstance;

            if (customer.MembershipTypeId == 0 || customer.MembershipTypeId == 1)
                return ValidationResult.Success;

            if (customer.DOB == null)
                return new ValidationResult("Birthday is required");

            var age = DateTime.Today.Year - customer.DOB.Value.Year;

            return (age >= 18) 
                ? ValidationResult.Success : 
                new ValidationResult("Customer should be at least 18 years");
        }
    }
}