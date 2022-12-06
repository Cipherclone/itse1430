    using Microsoft.AspNetCore.Mvc;

namespace MovieLibrary.WebApp.Controllers
{
    public class MovieController : Controller
    {
        public MovieController ( IConfiguration configuration )
        {
            var connString = configuration.GetConnectionString("AppDatabase");

            _database = new Sql.SqlMovieDatabase (connString);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Movie>> Index ()
        {
            var movies =  _database.GetAll();

            return View(movies);
        }

        public ActionResult<Movie> Detail ( int id )
        {
            var movie = _database.Get(id);

            return View(movie);

        }

        private readonly Sql.SqlMovieDatabase _database;
    }
}
