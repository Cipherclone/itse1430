/*
 * James Sparkman
 * Lab 3
 * Fall 2022
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using JamesSparkman.ContactManager.Library;

namespace JamesSparkman.ContactManager.UI
{
    public partial class ContactForm : Form
    {
        #region Construction
        public ContactForm ()
        {
            InitializeComponent();
        }
        #endregion

        /// <summary>Selected Contract used for editing.</summary>
        public Contact SelectedContact { get; set; }

        /// <summary>Puts the selected data into the texboxes.</summary>
        /// <param name="e"></param>
        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad ( e );

            if (SelectedContact != null)
            {
                _txtFirstName.Text = SelectedContact.FirstName;
                _txtLastName.Text = SelectedContact.LastName;
                _txtEmail.Text = SelectedContact.Email;
                _cbFavorite.Checked = SelectedContact.IsFavorite;
                _txtNotes.Text = SelectedContact.Notes;
            }

            ValidateChildren();
        }

        /// <summary>Saves contact made to the database</summary>
        private void OnSave ( object sender, EventArgs e )
        {
            if (!ValidateChildren())
                return;

            var btn = sender as Button;

            var contact = new Contact();
            contact.FirstName = _txtFirstName.Text;
            contact.LastName = _txtLastName.Text;
            contact.Notes = _txtNotes.Text;
            contact.Email = _txtEmail.Text;
            contact.IsFavorite = _cbFavorite.Checked;

            if (!ObjectValidator.IsValid(contact, out var error))
            {
                DisplayError(error, "Save");
                return;
            }

            SelectedContact = contact;
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>Cancels changes.</summary>
        private void OnCancel ( object sender, EventArgs e )
        {
            Close();
        }

        #region Private Members

        /// <summary>Shows an error message on screen.</summary>
        /// <param name="message">Error Message</param>
        /// <param name="title">Window Title</param>
        private void DisplayError (string message, string title)
        {
            MessageBox.Show (this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        
    }
}
