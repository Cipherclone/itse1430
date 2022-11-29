using System.Data.SqlClient;

namespace MovieLibrary.Sql
{
    public class SqlMovieDatabase : MovieDatabase
    {
        public SqlMovieDatabase(string connectionString)
        {
            _connectionString = connectionString;
        
        protected override Movie AddCore ( Movie movie )
        {
            SqlConnection conn = null;

            try
            {
                conn = OpenConnection();

                throw new NotImplementedException();
            } finally
            {
                // close connect
                conn.Close();   
            }
            
        }
        protected override Movie FindByTitle ( string title )
        {
            var conn = OpenConnection();

            // close connect
            conn.Close();
            // Find by ID
            return null;
        }
        protected override IEnumerable<Movie> GetAllCore () {
            var conn = OpenConnection();

            conn.Close();

            return Enumerable.Empty<Movie>();
        }
        protected override Movie GetCore ( int id )
        {
            var conn = OpenConnection();

            // close connect
            conn.Close();
            // Find by ID
            return null;
        }
        protected override void RemoveCore ( int id ) => throw new NotImplementedException();
        protected override void UpdateCore ( int id, Movie movie ) => throw new NotImplementedException();

        private SqlConnection OpenConnection ()
        {
            var conn = new SqlConnection(_connectionString);
            conn.Open();

            return conn;
        }

        private readonly string _connectionString;
    }
}