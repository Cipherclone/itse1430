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
        public ContactForm ()
        {
            InitializeComponent();
        }

        public Contact SelectedContact { get; set; }

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

        #region Private Members

        private void DisplayError (string message, string title)
        {
            MessageBox.Show (this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        #endregion
    }
}
