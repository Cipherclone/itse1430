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
        

        protected override Movie AddCore ( Movie movie)
        {
            //Add
            movie.Id = _id++;
            _movies.Add(movie.Clone());
            return movie;
        }

        protected override Movie GetCore ( int id )
        {
            return _movies.FirstOrDefault( x => x.Id == id )?.Clone(); 

            //foreach (var movie in _movies)
            //    if (movie?.Id == id)
            //        return movie.Clone();  //Clone because of ref type

            //return null;
        }

        protected override IEnumerable<Movie> GetAllCore ()
        {
            return _movies.Select( x => x.Clone() );

            // LINQ syntax
            //  from tempVar in IEnumerable<T>
            //  where <condition>
            //  orderby
            //  select
            //return from movie in _movies
                // ~~where movie.Id > 10~~ // OPTIONAL
                //orderby movie.Title, movie.ReleaseYear // OPTIONAL
                //select movie.Clone();

            //foreach (var movie in _movies)
            //{
            //    //items.Add(movie.Clone());
            //    yield return movie.Clone(); // the yield makes it an iterator!
            //}
        }

        protected override void RemoveCore ( int id )
        {
            var movie = FindById(id);
            if (movie == null)
                throw new NotSupportedException("Movie does not exist.");
            
            _movies.Remove( movie );
            //Enumerate array looking for match
            //for (var index = 0; index < _movies.Count; ++index)
            //    if (_movies[index]?.Id == id)
            //    {
            //        //_movies[index] = null;
            //        _movies.RemoveAt(index);
            //        return;
            //    };
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
            //return _movies.FirstOrDefault(FilterById);
            //foreach (var movie in _movies)
            //    if (movie.Id == id)
            //        return movie;

            //return null;
            return _movies.FirstOrDefault(x => x.Id == id);
        }

        ////private bool FilterById ( Movie movie )
        ////{
        ////    return true;
        ////}

        protected override Movie FindByTitle ( string title )
        {
            return _movies.FirstOrDefault(x => String.Equals(x.Title, title, StringComparison.OrdinalIgnoreCase));
            
            
            //foreach (var movie in _movies)
            //    if (String.Equals(movie.Title, title, StringComparison.OrdinalIgnoreCase))
            //        return movie;

            //return null;
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
