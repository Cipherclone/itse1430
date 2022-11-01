using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Memory
{
    public class MemoryMovieDatabase : MovieDatabase    
    {
        //TODO: Seed database
        public MemoryMovieDatabase ()
        {
            //Array/collection initializer syntax
            //var movies = new Movie[3];

            //Object initializer syntax
            //new Movie("Jaws", "PG");
            //var movie = new Movie();
            //movie.Title = "Jaws";
            //movie.Rating = "PG";
            //movie.RunLength = 210;
            //movie.ReleaseYear = 1977;
            //movie.Description = "Shark eats people";
            //movie.IsClassic = true;
            //movies[0] = new Movie() {
            //    Title = "Jaws",
            //    Rating = "PG",
            //    RunLength = 210,
            //    ReleaseYear = 1977,
            //    Description = "Shark eats people",
            //    IsClassic = true,
            //};            
            //movies[1] = new Movie() {
            //    Title = "Jaws 2",
            //    Rating = "PG-13",
            //    RunLength = 220,
            //    ReleaseYear = 1979,
            //    Description = "Shark eats people...again"                
            //};
            //movies[2] = new Movie() {
            //            Title = "Dune",
            //            Rating = "PG-13",
            //            RunLength = 320,
            //            ReleaseYear = 1985,
            //            Description = "Based on book",
            //        };
            var movies = new Movie[] {
                new Movie() {
                    Title = "Jaws",
                    Rating = "PG",
                    RunLength = 210,
                    ReleaseYear = 1977,
                    Description = "Shark eats people",
                    IsClassic = true,
                },
                new Movie() {
                    Title = "Jaws 2",
                    Rating = "PG-13",
                    RunLength = 220,
                    ReleaseYear = 1979,
                    Description = "Shark eats people...again"
                },
                new Movie() {
                    Title = "Dune",
                    Rating = "PG-13",
                    RunLength = 320,
                    ReleaseYear = 1985,
                    Description = "Based on book",
                }
            };
            foreach (var movie in movies)
                Add(movie, out var error);
        }

        protected override Movie AddCore ( Movie movie)
        {
            //Add
            movie.Id = _id++;
            _movies.Add(movie.Clone());
            return movie;
        }

        protected override Movie GetCore ( int id )
        {
            foreach (var movie in _movies)
                if (movie?.Id == id)
                    return movie.Clone();  //Clone because of ref type

            return null;
        }

        protected override IEnumerable<Movie> GetAllCore ()
        {

            foreach (var movie in _movies)
            {
                //items.Add(movie.Clone());
                yield return movie.Clone(); // the yield makes it an iterator!
            }
        }

        protected override void RemoveCore ( int id )
        {
            //Enumerate array looking for match
            for (var index = 0; index < _movies.Count; ++index)
                if (_movies[index]?.Id == id)
                {
                    //_movies[index] = null;
                    _movies.RemoveAt(index);
                    return;
                };
        }

        protected override void UpdateCore ( int id, Movie movie)
        {
            var oldMovie = FindById(id);
            //Copy 
            movie.CopyTo(oldMovie);
            oldMovie.Id = id;
        }

        #region Private Members

        private Movie FindById ( int id )
        {
            foreach (var movie in _movies)
                if (movie.Id == id)
                    return movie;

            return null;
        }

        protected override Movie FindByTitle ( string title )
        {
            foreach (var movie in _movies)
                if (String.Equals(movie.Title, title, StringComparison.OrdinalIgnoreCase))
                    return movie;

            return null;
        }

        private int _id = 1;

        //System.Collections.Generic
        //private Movie[] _movies = new Movie[100];
        private List<Movie> _movies = new List<Movie>();
        //private Collection<Movie> _movies = new Collection<Movie>();
        //List<string>;
        //  List<int>;
        #endregion
    }
}
