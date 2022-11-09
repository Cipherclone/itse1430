/*
 * James Sparkman
 * Lab 3
 * Fall 2022
 */

using JamesSparkman.ContactManager.Library; 

namespace JamesSparkman.ContactManager.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad ( e );

            UpdateUI(true);
        }

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


        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var about = new AboutForm();
            about.ShowDialog(this);
        }

        public void OnFormClosing ( object sender, EventArgs e )
        {
            // figure this out
            Close();
        }
        
        #region Private Members
        private void UpdateUI ()
        {
            UpdateUI(false);
        }
        private void UpdateUI (bool initialLoad)
        {
            var contacts = _contacts.GetAll();

            _lstContacts.Items.Clear();

            var items = contacts.OrderBy(x => x.LastName).ThenBy(x => x.FirstName).ToArray();
            _lstContacts.Items.AddRange(items);
        }

        private IContactDatabase _contacts = new ContactDatabase();
        #endregion

        
    }
}