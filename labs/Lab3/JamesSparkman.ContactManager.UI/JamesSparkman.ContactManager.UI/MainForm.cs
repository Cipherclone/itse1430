/*
 * James Sparkman
 * Lab 3
 * Fall 2022
 */

using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

using JamesSparkman.ContactManager.Library; 

namespace JamesSparkman.ContactManager.UI
{
    public partial class MainForm : Form
    {
        #region Construction
        public MainForm ()
        {
            InitializeComponent();
        }
        #endregion

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad ( e );

            UpdateUI(true);
        }

        protected override void OnFormClosing ( FormClosingEventArgs e ) {
            base.OnFormClosing(e);
        }

        #region Event Handlers

        /// <summary>Opens ContactForm for the purpose of adding a new contact.</summary>
        private void OnContactAdd ( object sender, EventArgs e )
        {
            var child = new ContactForm();

            do
            {
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;

                if (_contacts.Add(child.SelectedContact, out var error) != null)
                {
                    UpdateUI();
                    return;

                }
                //if (_contacts.Add(child.Sele))
            } while (true);
        }

        /// <summary>Opens ContactForm for the purpose of editing a contact.</summary>
        private void OnContactEdit ( object sender, EventArgs e )
        {
            var contact = GetSelectedContact();
            if (contact == null)
                return;

            var child = new ContactForm();
            child.SelectedContact = contact;

            do
            {
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;

                if (_contacts.Update(contact.Id, child.SelectedContact, out var error))
                {
                    UpdateUI();
                    return;
                };

                DisplayError(error, "Update Failed");
            } while (true);
        }

        /// <summary>Governs deleting a contact from the database.</summary>
        private void OnContactDelete ( object sender, EventArgs e )
        {
            var contact = GetSelectedContact();
            if (contact == null)
                return;

            if (!Confirm($"Are you sure you want to delete '{contact.FirstName} {contact.LastName}' ?", "Delete"))
                return;

            _contacts.Remove(contact.Id);
            UpdateUI();
        }

        /// <summary>Opens Help Menu.</summary>
        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var about = new AboutForm();
            about.ShowDialog(this);
        }

        /// <summary>Gives fuctionality to the exit button.</summary>
        public void OnFileClose ( object sender, EventArgs e )
        {
            // figure this out
            Close();
        }

        #endregion

        #region Private Members
        /// <summary>Updates what is shown on the list of contacts</summary>
        private void UpdateUI ()
        {
            UpdateUI(false);
        }

        /// <summary>Updates what is shown on the list of contacts</summary>
        /// <param name="initialLoad">Ask for seeding</param>
        private void UpdateUI (bool initialLoad)
        {
            var contacts = _contacts.GetAll();

            if (initialLoad && !contacts.Any())
            {
                if (Confirm("Do you want to seed some contacts?", "Database Empty!"))
                {
                    _contacts.SeedDataBase();
                    contacts = _contacts.GetAll();
                }
            }


            _lstContacts.Items.Clear();

            var items = contacts.OrderBy(x => x.LastName).ThenBy(x => x.FirstName).ToArray();
            _lstContacts.Items.AddRange(items);
        }

        /// <summary></summary>
        /// <returns>Selected Contact from list</returns>
        private Contact GetSelectedContact ()
        {
            return _lstContacts.SelectedItem as Contact;
        }

        /// <summary>Shows an error message on screen.</summary>
        /// <param name="message">Error Message</param>
        /// <param name="title">Window Title</param>
        private void DisplayError ( string message, string title )
        {
            MessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>Shows a confirmation box on screen</summary>
        /// <param name="message">Confirmation Message</param>
        /// <param name="title">Window Title</param>
        /// <returns>true if OK is clicked</returns>
        private bool Confirm ( string message, string title )
        {
            DialogResult result = MessageBox.Show(this, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            return result == DialogResult.Yes;
        }

        private IContactDatabase _contacts = new ContactDatabase();

        #endregion
        
    }
}