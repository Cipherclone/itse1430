using System.Data;
using System.Data.SqlClient;

namespace MovieLibrary.Sql
{
    public class SqlMovieDatabase : MovieDatabase
    {
        public SqlMovieDatabase ( string connectionString )
        {
            _connectionString = connectionString;
        }

        protected override Movie AddCore ( Movie movie )
        {
            //Using statement
            // IDisposable
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "AddMovie";
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@name", movie.Title);
                cmd.Parameters.AddWithValue("@rating", movie.Rating);
                cmd.Parameters.AddWithValue("@description", movie.Description);
                cmd.Parameters.AddWithValue("@releaseYear", movie.ReleaseYear);
                cmd.Parameters.AddWithValue("@runLength", movie.RunLength);
                cmd.Parameters.AddWithValue("@isClassic", movie.IsClassic);

                // Execute Command
                object result = cmd.ExecuteScalar();
                movie.Id = Convert.ToInt32(result);
                return movie;
            };

            #region try-finally equivalent
            //SqlConnection conn = null;

            //try
            //{
            //    conn = OpenConnection();

            //    throw new NotImplementedException();
            //} finally
            //{
            //    //Clean up connection
            //    conn?.Close();
            //    conn?.Dispose();
            //};
            #endregion
        }

        protected override Movie FindByTitle ( string title )
        {
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("FindByName", conn);
                cmd.Parameters.AddWithValue("@name", title);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return new Movie() {
                            Id = (int)reader[0],
                            Title = reader["Name"] as string,
                            Description = reader["Description"] as string,
                            RunLength = reader.GetInt32("Runlength"),
                            Rating = reader.GetString("Rating"),
                            ReleaseYear = reader.GetFieldValue<int>("ReleaseYear"),
                            IsClassic = reader.GetFieldValue<bool>("IsClassic") 
                        };
                    };
                };
            };
            return null;
        }

        protected override IEnumerable<Movie> GetAllCore ()
        {
            var ds = new DataSet();

            using (var conn = OpenConnection())
            {
                //Create command 1 - using new
                var cmd = new SqlCommand("GetMovies", conn);

                //Need data adapter for Dataset
                var da = new SqlDataAdapter(cmd);

                //Buffered IO                
                da.Fill(ds);
            };

            //Data loaded, can work with it now
            // Find table and then enumerate rows to get data
            var table = ds.Tables.OfType<DataTable>().FirstOrDefault();
            if (table != null)
            {
                foreach (DataRow row in table.Rows.OfType<DataRow>())
                {
                    yield return new Movie() {
                        Id = (int)row[0],                   //Ordinal index with cast
                        Title = row["Name"] as string,      //Name with cast
                        Description = row.IsNull(2) ? "" : row.Field<string>(2), //Ordinal index with generic
                        Rating = row.Field<string>("Rating"), //Column with generic
                        RunLength = row.Field<int>("RunLength"),
                        ReleaseYear = row.Field<int>("ReleaseYear"),
                        IsClassic = row.Field<bool>("IsClassic"),
                    };
                };
            };
        }

        protected override Movie GetCore ( int id )
        {
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("GetMovie", conn);
                cmd.Parameters.AddWithValue("@id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return new Movie() {
                            Id = (int)reader[0],
                            Title = reader["Name"] as string,
                            Description = reader["Description"] as string,
                            RunLength = reader.GetInt32("Runlength"),
                            Rating = reader.GetString("Rating"),
                            ReleaseYear = reader.GetFieldValue<int>("ReleaseYear"),
                            IsClassic = reader.GetFieldValue<bool>("IsClassic")
                        };
                    };
                };
            };
            return null;
        }

        protected override void RemoveCore ( int id )
        {
            using (var conn = OpenConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DeleteMovie";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                cmd.Parameters.AddWithValue("@id",id);

                cmd.ExecuteNonQuery();
            };
        }
        protected override void UpdateCore ( int id, Movie movie )
        {
            using (var conn = OpenConnection())
            {
                
                var cmd = new SqlCommand();
                cmd.CommandText = "UpdateMovie";
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", movie.Title);
                cmd.Parameters.AddWithValue("@rating", movie.Rating);
                cmd.Parameters.AddWithValue("@description", movie.Description);
                cmd.Parameters.AddWithValue("@releaseYear", movie.ReleaseYear);
                cmd.Parameters.AddWithValue("@runLength", movie.RunLength);
                cmd.Parameters.AddWithValue("@isClassic", movie.IsClassic);

                // Execute Command
                cmd.ExecuteNonQuery();

                #region SQL Injection
                //var cmd2 = new SqlCommand($"SELECT * FROM Movies WHERE Name = @title");
                //cmd2.Parameters.AddWithValue("@title", movie.Title);
                #endregion
            };
        }

        private SqlConnection OpenConnection ()
        {
            var conn = new SqlConnection(_connectionString);
            conn.Open();

            return conn;
        }

        private readonly string _connectionString;
    }
}