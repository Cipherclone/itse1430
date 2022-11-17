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

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            UpdateUI(true);
        }

        #region Event Handlers

        //Called to handle Movies\Add
        private void OnMovieAdd ( object sender, EventArgs e )
        {
            var child = new MovieForm();

            do
            {
                //Showing form modally
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;

                try
                {
                    _movies.Add(child.SelectedMovie);
                    UpdateUI();
                    return;
                } catch (InvalidOperationException ex)
                {
                    DisplayError("Movies must be unique.", "Add failed");
                } catch (ArgumentException ex)
                {
                    DisplayError("You messed up dev..", "Add Failed");
                } catch (Exception ex)
                {
                    DisplayError(ex.Message, "Add Failed");

                }


            } while (true);
        }

        private void OnMovieDelete ( object sender, EventArgs e )
        {
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            if (!Confirm($"Are you sure you want to delete '{movie.Title}'?", "Delete"))
                return;

            try
            {
                _movies.Remove(movie.Id);
                UpdateUI();
            } catch (Exception ex)
            {
                DisplayError(ex.Message, "Delete Fail");
            };
        }

        private void OnMovieEdit ( object sender, EventArgs e )
        {
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            var child = new MovieForm();
            child.SelectedMovie = movie;

            do
            {
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;


                try
                {
                    Cursor = Cursors.WaitCursor;
                    _movies.Update(movie.Id, child.SelectedMovie);
                    UpdateUI();
                    return;

                } catch (Exception ex)
                {
                    DisplayError(ex.Message, "Update Failed");
                } finally
                {
                    Cursor = Cursors.Default;
                };
            } while (true);
        }

        private void OnFileExit ( object sender, EventArgs e )
        {
            Close();
        }

        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var about = new AboutForm();

            about.ShowDialog();
        }
        #endregion

        #region Private Members

        private void UpdateUI ()
        {
            UpdateUI(false);
        }

        private void UpdateUI ( bool initialLoad)
        {
            //Get movies
            var movies = _movies.GetAll();
            
            //if (initialLoad && movies.Count() == 0)
            if (initialLoad && !movies.Any())
            {
                if (Confirm("Do you want to seed some movies?", "Database Empty!"))
                {
                    _movies.Seed();
                    movies = _movies.GetAll();
                };
            };

            _lstMovies.Items.Clear();

            var items = movies.OrderBy(x => x.Title).ThenBy(x => x.ReleaseYear).ToArray();
            //var items = movies.OrderBy(OrderByTitle).ThenBy(OrderByReleaseYear).ToArray();

            _lstMovies.Items.AddRange(items);
            //foreach (var movie in movies)
            //    _lstMovies.Items.Add(movie);
        }

        private string OrderByTitle (Movie movie)
        {
            return movie.Title;
        }

        private int OrderByReleaseYear (Movie movie)
        {
            return movie.ReleaseYear;
        }

        private Movie GetSelectedMovie ()
        {
            //IEnumerable<Movie> temp = _lstMovies.SelectedItems.OfType<Movie>();
            return _lstMovies.SelectedItem as Movie;
        }

        private bool Confirm ( string message, string title )
        {
            DialogResult result = MessageBox.Show(this, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            return result == DialogResult.Yes;
        }

        private void DisplayError ( string message, string title )
        {
            MessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //private Movie _movie;
        private IMovieDatabase _movies = new Sql.SqlMovieDatabase(Program.GetConnectionString("AppDatabase"));
        #endregion        
    }
}