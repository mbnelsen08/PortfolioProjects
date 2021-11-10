using DvdLibraryApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DvdLibraryApi.Data
{
    public class TestRepository : IMovieRepository
    {
        private static List<Movie> _movies = new List<Movie>
            {
                new Movie {DvdId=1,Title="Ghostbusters",Rating="PG-13",ReleaseYear="1990",Director="George",Notes="Lots of ghosts in this one."},
                new Movie {DvdId=2,Title="Finding Nemo",Rating="G",ReleaseYear="1972",Director="Stan",Notes="Lots of ghosts in this one."},
                new Movie {DvdId=3,Title="Rocky",Rating="PG-13",ReleaseYear="1972",Director="Kevin",Notes="Lots of ghosts in this one."}
            };

        public Movie GetMovieById(int id)
        {
            return _movies.FirstOrDefault(m => m.DvdId == id);
        }

        public IEnumerable<Movie> GetMovies()
        {
            return _movies;
        }

        public void MovieAdd(Movie movie)
        {
            movie.DvdId = _movies.Max(m => m.DvdId) + 1;
            _movies.Add(movie);
        }

        public void MovieDelete(int id)
        {
            _movies.RemoveAll(m => m.DvdId == id);
        }

        public void MovieEdit(Movie movie)
        {
            var found = _movies.FirstOrDefault(m => m.DvdId == movie.DvdId);
            if (found != null)
                found = movie;
        }

        public IEnumerable<Movie> SearchByDirector(string searchText)
        {
            return _movies.FindAll(m => m.Director == searchText);
        }

        public IEnumerable<Movie> SearchByRating(string searchText)
        {
            return _movies.FindAll(m => m.Rating == searchText);
        }

        public IEnumerable<Movie> SearchByTitle(string searchText)
        {
            return _movies.FindAll(m => m.Title == searchText);
        }

        public IEnumerable<Movie> SearchByYear(string searchText)
        {
            return _movies.FindAll(m => m.ReleaseYear == searchText);
        }
    }
}