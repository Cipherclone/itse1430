/*
 * James Sparkman
 * Lab 3
 * Fall 2022
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace JamesSparkman.ContactManager.Library
{
    public abstract class ContactDatabase : IContactDatabase
    {
        /// <summary>Adds a Contact to the database</summary>
        /// <param name="contact">Contact to add</param>
        /// <param name="errorMessage">Error message, if any</param>
        /// <returns>The new contact</returns>
        /// <remarks>
        /// Fails if:
        ///  - Contact is null
        ///  - Contact is not valid
        ///  - Contact Email already exists
        /// </remarks>
        public Contact Add (Contact contact, out string errorMessage)
        {
            if (contact == null)
            {
                errorMessage = "Contact cannot be null";
                return null;
            };

            if (!ObjectValidator.IsValid(contact, out errorMessage))
                return null;

            var existing = FindByEmail(contact.Email);
            if (existing != null)
            {
                errorMessage = "Contact must be unique";
                return null;
            };

            errorMessage = null;
            contact.Id = _id++;
            _contacts.Add(contact.Clone());
            return contact;
        }

        /// <summary>Gets a Contact</summary>
        /// <param name="id">ID of the contact</param>
        /// <returns>The contact, if any</returns>
        /// <remarks>
        /// Fails if:
        ///  - Id is less than 1
        /// </remarks>
        public Contact Get (int id)
        {
            foreach (var contact in _contacts)
                if (contact?.Id == id)
                    return contact.Clone();
            return null;
        }

        /// <summary>Gets all the contacts</summary>
        /// <returns>The contacts</returns>
        public IEnumerable<Contact> GetAll ()
        {
            foreach (var contact in _contacts)
                yield return contact.Clone();
        }

        /// <summary>Remove a contact</summary>
        /// <param name="id">ID of the contact to remove</param>
        /// <remarks>
        /// Fails if:
        ///  - Id is less than 1
        /// </remarks>
        public void Remove (int id)
        {
            if (id <= 0)
                return;

            for (var index = 0; index < _contacts.Count; ++index)
                if (_contacts[index]?.Id == id)
                {
                    _contacts.RemoveAt(index);
                    return;
                };

        }

        /// <summary>Updates a contact in the database</summary>
        /// <param name="id">Id of the contact</param>
        /// <param name="contact">The new contact information</param>
        /// <param name="errorMessage">Error message, if any</param>
        /// <returns>True if successful</returns>
        /// <remarks>
        /// Fails if: 
        ///  - Id is less that 1
        ///  - Contact does not already exist
        ///  - Contact is null
        ///  - Contact is not valid
        ///  - Contact Email already exists
        /// </remarks>
        public bool Update ( int id, Contact contact, out string errorMessage )
        {
            if (contact == null)
            {
                errorMessage = "Contact cannot be null";
                return false;
            };

            if (!ObjectValidator.IsValid(contact, out errorMessage))
                return false;

            var oldContact = Get(id);
            if (oldContact == null)
            {
                errorMessage = "Contact does not exist";
                return false;
            };

            var existing = FindByEmail(contact.Email);
            if (existing != null && existing.Id != id)
            {
                errorMessage = "Contact must be unique";
                return false;
            };

            var replaceContact = FindById(id);
            contact.CopyTo(replaceContact);
            replaceContact.Id = id;
            errorMessage = null;
            return true;
        }

        #region Private Members
        
        /// <summary>Finds Contact by ID</summary>
        /// <param name="id">Id to search with</param>
        /// <returns>Contact with appropriate ID, if any</returns>
        private Contact FindById (int id)
        {
            foreach (var contact in _contacts)
                if (contact.Id == id)
                    return contact;
            return null;
        }

        /// <summary>Find Contact by Email Address</summary>
        /// <param name="email">Email to search with</param>
        /// <returns>Contact with appropriate Email, if any</returns>
        private Contact FindByEmail (string email)
        {
            foreach (var contact in _contacts)
                if (String.Equals(contact.Email, email, StringComparison.OrdinalIgnoreCase))
                    return contact;
            return null;
        }

        private int _id = 1;
        private List<Contact> _contacts = new List<Contact>();
        
        #endregion
    }
}
