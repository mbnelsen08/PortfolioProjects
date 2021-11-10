using DvdLibraryApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DvdLibraryApi.Data
{
    public class DapperRepository : IMovieRepository
    {
        public Movie GetMovieById(int id)
        {
            Movie movie = new Movie();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "GetMovieById";

                cmd.Parameters.AddWithValue("@DvdId", id);

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        movie.DvdId = (int)dr["DvdId"];
                        movie.Title = dr["Title"].ToString();
                        movie.ReleaseYear = dr["ReleaseYear"].ToString();

                        if (dr["Director"] != DBNull.Value)
                        {
                            movie.Director = dr["Director"].ToString();
                        }

                        if (dr["Notes"] != DBNull.Value)
                        {
                            movie.Notes = dr["Notes"].ToString();
                        }

                        if (dr["Director"] != DBNull.Value)
                        {
                            movie.Rating = dr["Rating"].ToString();
                        }
                    }
                }
            }

            return movie;
        }

        public IEnumerable<Movie> GetMovies()
        {
            List<Movie> movies = new List<Movie>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "AllMovies";

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Movie currentRow = new Movie();

                        currentRow.DvdId = (int)dr["DvdId"];
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.ReleaseYear = dr["ReleaseYear"].ToString();

                        if (dr["Director"] != DBNull.Value)
                        {
                            currentRow.Director = dr["Director"].ToString();
                        }

                        if (dr["Notes"] != DBNull.Value)
                        {
                            currentRow.Notes = dr["Notes"].ToString();
                        }

                        if (dr["Director"] != DBNull.Value)
                        {
                            currentRow.Rating = dr["Rating"].ToString();
                        }

                        movies.Add(currentRow);
                    }
                }
            }

            return movies;
        }

        public void MovieAdd(Movie movie)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "MovieAdd";

                cmd.Parameters.AddWithValue("@DvdId", movie.DvdId);
                cmd.Parameters.AddWithValue("@Title", movie.Title);
                cmd.Parameters.AddWithValue("@ReleaseYear", movie.ReleaseYear);
                cmd.Parameters.AddWithValue("@Director", movie.Director);
                cmd.Parameters.AddWithValue("@Rating", movie.Rating);
                cmd.Parameters.AddWithValue("@Notes", movie.Notes);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void MovieDelete(int id)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "MovieDelete";

                cmd.Parameters.AddWithValue("@DvdId", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void MovieEdit(Movie movie)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "MovieUpdate";

                cmd.Parameters.AddWithValue("@DvdId", movie.DvdId);
                cmd.Parameters.AddWithValue("@Title", movie.Title);
                cmd.Parameters.AddWithValue("@ReleaseYear", movie.ReleaseYear);
                cmd.Parameters.AddWithValue("@Director", movie.Director);
                cmd.Parameters.AddWithValue("@Rating", movie.Rating);
                cmd.Parameters.AddWithValue("@Notes", movie.Notes);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<Movie> SearchByDirector(string searchText)
        {
            List<Movie> movies = new List<Movie>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "GetMovieByDirector";

                cmd.Parameters.AddWithValue("@searchText", searchText);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Movie currentRow = new Movie();

                        currentRow.DvdId = (int)dr["DvdId"];
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.ReleaseYear = dr["ReleaseYear"].ToString();

                        if (dr["Director"] != DBNull.Value)
                        {
                            currentRow.Director = dr["Director"].ToString();
                        }

                        if (dr["Notes"] != DBNull.Value)
                        {
                            currentRow.Notes = dr["Notes"].ToString();
                        }

                        if (dr["Director"] != DBNull.Value)
                        {
                            currentRow.Rating = dr["Rating"].ToString();
                        }

                        movies.Add(currentRow);
                    }
                }
            }

            return movies;
        }

        public IEnumerable<Movie> SearchByRating(string searchText)
        {
            List<Movie> movies = new List<Movie>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "GetMovieByRating";

                cmd.Parameters.AddWithValue("@searchText", searchText);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Movie currentRow = new Movie();

                        currentRow.DvdId = (int)dr["DvdId"];
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.ReleaseYear = dr["ReleaseYear"].ToString();

                        if (dr["Director"] != DBNull.Value)
                        {
                            currentRow.Director = dr["Director"].ToString();
                        }

                        if (dr["Notes"] != DBNull.Value)
                        {
                            currentRow.Notes = dr["Notes"].ToString();
                        }

                        if (dr["Director"] != DBNull.Value)
                        {
                            currentRow.Rating = dr["Rating"].ToString();
                        }

                        movies.Add(currentRow);
                    }
                }
            }

            return movies;
        }

        public IEnumerable<Movie> SearchByTitle(string searchText)
        {
            List<Movie> movies = new List<Movie>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "GetMovieByTitle";

                cmd.Parameters.AddWithValue("@searchText", searchText);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Movie currentRow = new Movie();

                        currentRow.DvdId = (int)dr["DvdId"];
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.ReleaseYear = dr["ReleaseYear"].ToString();

                        if (dr["Director"] != DBNull.Value)
                        {
                            currentRow.Director = dr["Director"].ToString();
                        }

                        if (dr["Notes"] != DBNull.Value)
                        {
                            currentRow.Notes = dr["Notes"].ToString();
                        }

                        if (dr["Director"] != DBNull.Value)
                        {
                            currentRow.Rating = dr["Rating"].ToString();
                        }

                        movies.Add(currentRow);
                    }
                }
            }

            return movies;
        }

        public IEnumerable<Movie> SearchByYear(string searchText)
        {
            List<Movie> movies = new List<Movie>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "GetMovieByYear";

                cmd.Parameters.AddWithValue("@searchText", searchText);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Movie currentRow = new Movie();

                        currentRow.DvdId = (int)dr["DvdId"];
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.ReleaseYear = dr["ReleaseYear"].ToString();

                        if (dr["Director"] != DBNull.Value)
                        {
                            currentRow.Director = dr["Director"].ToString();
                        }

                        if (dr["Notes"] != DBNull.Value)
                        {
                            currentRow.Notes = dr["Notes"].ToString();
                        }

                        if (dr["Director"] != DBNull.Value)
                        {
                            currentRow.Rating = dr["Rating"].ToString();
                        }

                        movies.Add(currentRow);
                    }
                }
            }

            return movies;
        }
    }
}