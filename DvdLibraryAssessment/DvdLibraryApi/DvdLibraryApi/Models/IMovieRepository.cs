using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibraryApi.Models
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetMovies();
        Movie GetMovieById(int id);

        void MovieDelete(int id);

        void MovieAdd(Movie movie);

        void MovieEdit(Movie movie);

        IEnumerable<Movie> SearchByTitle(string searchText);

        IEnumerable<Movie> SearchByRating(string searchText);

        IEnumerable<Movie> SearchByDirector(string searchText);

        IEnumerable<Movie> SearchByYear(string searchText);
    }
}
