namespace MovieLibrary.WinHost
{
    public partial class MainForm : Form
    {
        #region Construction

        public MainForm ()
        {
            InitializeComponent();
        }
        #endregion
        
        //Called to handle Movies\Add
        private void OnMovieAdd ( object sender, EventArgs e )
        {
            var child = new MovieForm();

            //Showing form modally
            if (child.ShowDialog() != DialogResult.OK)
                return;
            //child.Show();

            //TODO: Save this off
            _movie = child.SelectedMovie;
            UpdateUI();
        }

        private Movie _movie;

        private void OnMovieDelete ( object sender, EventArgs e )
        {
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            if (!Confirm($"Are you sure you want to delete '{movie.Title}'?", "Delete"))
                return;

            //TODO: Implement Delete
            _movie = null;
            UpdateUI();
        }

        protected override void OnFormClosing ( FormClosingEventArgs e )
        {
            base.OnFormClosing(e);

            if (Confirm("Are you sure you want to leave?", "Close"))
                return;

            //Stop the event
            e.Cancel = true;
        }

        protected override void OnFormClosed ( FormClosedEventArgs e )
        {
            base.OnFormClosed(e);
        }

        #region Private Members

        private void UpdateUI ()
        {
            //TODO: Get movies

            _lstMovies.Items.Clear();
            if (_movie != null)
            {
                _lstMovies.Items.Add(_movie);
            };
        }

        private Movie GetSelectedMovie ()
        {
            return _movie;
        }

        private bool Confirm ( string message, string title )
        {
            DialogResult result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            return result == DialogResult.Yes;
        }

        private void DisplayError ( string message, string title )
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        private void OnMovieEdit ( object sender, EventArgs e )
        {
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            var child = new MovieForm();
            child.SelectedMovie = movie;

            if (child.ShowDialog() != DialogResult.OK)
                return;

            //TODO: Save this off
            _movie = child.SelectedMovie;
            UpdateUI();
        }
    }
}