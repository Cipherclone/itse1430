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
        /// <summary>Tests if an object is Valid.</summary>
        /// <param name="instance">Object to validate</param>
        /// <param name="errorMessage">Error Message, if any</param>
        /// <returns></returns>
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
