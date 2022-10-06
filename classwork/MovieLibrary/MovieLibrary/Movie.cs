namespace MovieLibrary
{
    /// <summary>Represents a movie.</summary>
    public class Movie
    {
        
        public Movie () : this("", "")
        {
            
        }

        public Movie ( string title ) : this(title, "")
        {
            
        }

        public Movie ( string title, string description ) : base() // Object.ctor()
        {
            Title = title;
            Description = description;
        }

        /// <summary>Gets the unique ID.</summary>
        public int Id { get; private set; }

        /// <summary>Gets or sets the title.</summary>
        public string Title
        {
            get {
                return _title ?? "";
            }

            set { _title = value?.Trim() ?? ""; }
        }
        private string _title;


        /// <summary>Gets or sets the description.</summary>
        public string Description
        {
            get { return _description ?? ""; }
            set { _description = value?.Trim() ?? ""; }
        }
        private string _description;

        /// <summary>Gets or sets the run length in minutes.</summary>
        public int RunLength { get; set; }

        /// <summary>Gets or sets the release year.</summary>
        /// <value>Default is 1900.</value>
        public int ReleaseYear { get; set; } = 1900;

        /// <summary>Gets or sets the MPAA rating.</summary>
        public string Rating
        {
            get { return _rating ?? ""; }
            set { _rating = value?.Trim() ?? ""; }
        }
        private string _rating;

        /// <summary>Determines if the movie is a classic.</summary>
        public bool IsClassic { get; set; }

        /// <summary>Determines if the movie is black and white.</summary>
        public bool IsBlackAndWhite
        {
            get { return ReleaseYear < YearColorWasIntroduced; }
            
        }

        public const int YearColorWasIntroduced = 1939;

        /// <summary>Clones the existing movie.</summary>
        /// <returns>A copy of the movie.</returns>
        public Movie Clone ()
        {
            var movie = new Movie();
            CopyTo(movie);

            return movie;
        }

        /// <summary>Copy the movie to another instance.</summary>
        /// <param name="movie">Movie to copy into.</param>
        public void CopyTo ( /* Movie this */ Movie movie )
        {

            movie.Title = Title;
            movie.Description = Description;
            movie.RunLength = RunLength;
            movie.ReleaseYear = ReleaseYear;
            movie.Rating = Rating;
            movie.IsClassic = IsClassic;

        }


        public override string ToString ()
        {
            var str = base.ToString();
            return Title;
        }
    }
}