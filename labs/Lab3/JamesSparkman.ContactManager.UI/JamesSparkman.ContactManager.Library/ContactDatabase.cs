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

            contact = AddCore(contact);

            errorMessage = null;
            return contact;
        }

        protected abstract Contact AddCore ( Contact contact );




        protected abstract Contact FindByEmail ( string email );
    }
}
