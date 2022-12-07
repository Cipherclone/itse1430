/*
 * ITSE 1430
 */
using System.ComponentModel.DataAnnotations;

namespace Nile
{
    /// <summary>Represents a product.</summary>
    public class Product : IValidatableObject
    {
        /// <summary>Gets or sets the unique identifier.</summary>
        public int Id { get; set; }

        /// <summary>Gets or sets the name.</summary>
        /// <value>Never returns null.</value>
        [Required(AllowEmptyStrings = false)]
        [StringLengthAttribute(100, MinimumLength = 1)]
        public string Name
        {
            get { return _name ?? ""; }
            set { _name = value?.Trim(); }
        }
        
        /// <summary>Gets or sets the description.</summary>
        public string Description
        {
            get { return _description ?? ""; }
            set { _description = value?.Trim(); }
        }

        /// <summary>Gets or sets the price.</summary>
        [Range(0, Int32.MaxValue, ErrorMessage = "Price must be >= 0")]
        [Display(Name = "Price")]
        public decimal Price { get; set; } = 0;      

        /// <summary>Determines if discontinued.</summary>
        public bool IsDiscontinued { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public IEnumerable<ValidationResult> Validate (ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            if (Id < 0)
                errors.Add(new ValidationResult("ID must be greater or equal to zero", new[] { nameof(Id) }));
            if (Name.Length == 0)
                errors.Add(new ValidationResult("Name is required", new[] { nameof(Name)}));
            if (Price < 0)
                errors.Add(new ValidationResult("Price must be greater or equal to zero", new[] { nameof(Price) }));
            return errors;
        }

        #region Private Members

        private string _name;
        private string _description;
        #endregion
    }
}
