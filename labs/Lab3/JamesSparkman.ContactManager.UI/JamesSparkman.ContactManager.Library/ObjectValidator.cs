/*
 * James Sparkman
 * Lab 3
 * Fall 2022
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamesSparkman.ContactManager.Library
{
    public static class ObjectValidator
    {
        public static bool IsValid (IValidatableObject instance, out string errorMessage)
        {
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(instance, new ValidationContext(instance), results, true))
            {
                errorMessage = results[0].ErrorMessage;
                return false;
            };

            errorMessage = null;
            return true;
        }
    }
}
