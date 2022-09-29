namespace MovieLibrary
{
    
    /// <summary>
    /// Represents a movie.
    /// </summary>
    public class Movie
    {
        public int Id { get; private set; }
        
        /// <summary> Gets or sets the title. </summary>
        public string Title
        {
            get { return String.IsNullOrEmpty(_title) ? "" : _title; }
            set { _title = String.IsNullOrEmpty(value) ? "" : value.Trim(); }
        }

        //public string GetTitle()
        //{
        //    return _title;
        //}
        //public void SetTitle(string title)
        //{
        //    _title = title;
        //}

        public string Description
        {
            get { return String.IsNullOrEmpty(_description) ? "" : _description; }
            set { _description = String.IsNullOrEmpty(value) ? "" : value.Trim(); }

        }

        /// <summary> Gets or sets the run length in minutes. </summary>
        //public int RunLength
        //{
        //    get { return _runLength;  }
        //    set { _runLength = value; }
        //}
        public int RunLength { get; set; }

        public int ReleaseYear { get; set; } = 1900;

        public string Rating
        {
            get { return String.IsNullOrEmpty(_rating) ? "" : _rating; }
            set { _rating = String.IsNullOrEmpty(value) ? "" : value.Trim(); }
        }

        public bool IsClassic { get; set; } = false;
        
        public bool IsBlackAndWhite
        {
            get { return ReleaseYear < 1939; }
            set { }
        }
        
        private string _title;
        private string _description;
        //private int _runLength = 0; // in minutes
        //private int _releaseYear = 1900;
        private string _rating;
        //private bool _isClassic = false;

        //public bool _isBlackAndWhite ()
        //{
        //    return _releaseYear < 1939;
        //}

        
        /// <summary>Clones the existing movie.</summary>
        /// <returns>A copy of the movie.</returns>
        public Movie Clone()
        {
            var movie = new Movie();
            CopyTo(movie);

            return movie;
        }

        /// <summary>Copy the movie to another instance</summary>
        /// <param name="movie">Movie to copy into.</param>
        public void CopyTo( /* Movie this */ Movie movie)
        {
            
            movie._title = _title;
            movie._description = _description;
            movie.RunLength = RunLength;
            movie.ReleaseYear = ReleaseYear;
            movie._rating = _rating;
            movie.IsClassic = IsClassic;
        }

    }
}