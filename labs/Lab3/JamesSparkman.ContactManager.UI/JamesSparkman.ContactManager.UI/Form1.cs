/*
 * James Sparkman
 * Lab 3
 * Fall 2022
 */

namespace JamesSparkman.ContactManager.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var about = new AboutForm();
            about.ShowDialog(this);
        }

        public void OnFormClosing ( object sender, EventArgs e )
        {
            // figure this out
            
        }
    }
}