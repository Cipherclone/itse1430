using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary
{
    public class MovieDatabase
    {
        // todo seed
        public MovieDatabase ()
        {
            //var movie = new Movie();
            //movie.Title = "Jaws";
            //movie.Rating = "R";
            //movie.RunLength = 120;
            //movie.ReleaseYear = 1977;
            //movie.IsClassic = true;
            //Add(movie, out var error);
            var movie = new Movie() {
                Title = "Jaws",
                Rating = "R",
                RunLength = 120,
                ReleaseYear = 1977,
                IsClassic = true,
            };

            Add(movie, out var error);
        }
    
        public virtual Movie Add ( Movie movie, out string errorMessage)
        {
            //var numberOfElements = _movies.Length;
            //_movie = movie;
            if (movie == null)
            {
                errorMessage = "Movie cannot be null";
                return null;
            };

            if (!movie.Validate(out errorMessage))
                return null;

            var existing = FindByTitle(movie.Title);
            if (existing != null)
            {
                errorMessage = "Movie must be unique";
                return null;
            }

            //add
            movie.Id = _id++;
            _movies.Add(movie.Clone());
            return movie;
        }

        public bool Update (int id, Movie movie, out string errorMessage)
        {
            if (movie == null)
            {
                errorMessage = "Movie cannot be null";
                return false;
            };

            if (!movie.Validate(out errorMessage))
                return false;

            var oldMovie = FindById(id);
            if (oldMovie == null)
            {
                errorMessage = "Movie does not exist";
                return false;   
            }

            var existing = FindByTitle(movie.Title);
            if (existing != null && existing.Id != id)
            {
                errorMessage = "Movie must be unique";
                return false;
            };
            // movie must already exist
            //add
            movie.CopyTo(oldMovie);
            return true;
        }

        public Movie Get ( int id )
        {
            foreach (var movie in _movies)
                if (movie?.Id == id)
                    return movie.Clone();
            
            return null;
        }

        /// <summary> Gets all the Movies. </summary>
        /// <returns>The movies</returns>
        public Movie[] GetAll ()
        {
            // TODO filter out null movies
            var items = new Movie[_movies.Count];
            var index = 0;
            foreach (var movie in _movies)
                items[index++] = movie.Clone();


            return items;
        }

        public void Remove(int id )
        {
            // TODO Switch to foreach
            for (var index = 0; index < _movies.Count; ++index)
                if (_movies[index]?.Id == id)
                {
                    _movies.RemoveAt(index);
                    return;
                }
        }

        #region Private Members

        private Movie FindByTitle (string title)
        {
            foreach (var movie in _movies)
                if (String.Equals(movie.Title, title, StringComparison.OrdinalIgnoreCase))
                    return movie;
            return null;
        }

        private Movie FindById ( int id )
        {
            foreach (var movie in _movies)
                if (movie.Id == id)
                    return movie;
            return null;
        }


        private List<Movie> _movies = new List<Movie>();
        private int _id = 1;

        #endregion
    }
}
