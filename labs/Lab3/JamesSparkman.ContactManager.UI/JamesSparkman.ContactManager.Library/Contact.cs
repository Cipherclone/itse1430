/*
 * James Sparkman
 * Lab 3
 * Fall 2022
 */
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;


namespace JamesSparkman.ContactManager.Library
{
    /// <summary>Represents a Contact</summary>
    public class Contact : IValidatableObject
    {
        #region Construction
        // TODO add constructors
        public Contact ()
        {
            
        }
        #endregion
        
        /// <summary>Gets the unique ID.</summary>
        public int Id { get; set; }

        /// <summary>Optional First Name</summary>
        public string FirstName 
        {
            get { return _firstName ?? ""; }
            set { _firstName = value?.Trim() ?? ""; }
        }
        private string _firstName;
        
        /// <summary>Required Last Name</summary>
        public string LastName 
        {
            get { return _lastName ?? ""; }
            set { _lastName = value?.Trim() ?? ""; } 
        }
        private string _lastName;

        /// <summary>Required and Unique E-Mail Address</summary>
        public string Email 
        {
            get { return _email ?? ""; } 
            set { _email = value?.Trim() ?? ""; }
        }
        private string _email;
        
        /// <summary>Optional Notes</summary>
        public string Notes 
        { 
            get { return _notes ?? ""; }
            set { _notes = value ?.Trim() ?? ""; } 
        }
        private string _notes;
        
        /// <summary>Bool Representing if a Contact is listed as a Favorite</summary>
        public bool IsFavorite { get; set; } = false;

        /// <summary>Checks if a given string is an Email Address</summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public bool IsValidEmail(string source)
        {
            return MailAddress.TryCreate(source, out var address);
        }

        /// <summary>Clones a Contact Object</summary>
        /// <returns>copy of the original Contact</returns>
        public Contact Clone ()
        {
            var contact = new Contact();
            CopyTo(contact);
            return contact;
        }

        /// <summary>Passes on data from this contact to another</summary>
        /// <param name="contact">Contact to copy to</param>
        public void CopyTo (Contact contact)
        {
            contact.Id = Id;
            contact.FirstName = FirstName;
            contact.LastName = LastName;
            contact.Email = Email;
            contact.Notes = Notes;
            contact.IsFavorite = IsFavorite;
        }

        /// <summary>
        /// Validates a E-Mail
        /// </summary>
        /// <param name="validationContext"></param>
        /// <returns>List of Errors (if any)</returns>
        public IEnumerable<ValidationResult> Validate (ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            if (LastName.Length == 0)
                errors.Add(new ValidationResult("Last name is required", new[] { nameof(LastName) }));
            if (!IsValidEmail(Email))
                errors.Add(new ValidationResult("A Valid Email is required", new[] { nameof(Email) }));

            return errors;
        }
    }
}