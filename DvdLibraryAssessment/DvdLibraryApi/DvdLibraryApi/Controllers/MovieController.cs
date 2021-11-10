using DvdLibraryApi.Data;
using DvdLibraryApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DvdLibraryApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MovieController : ApiController
    {
        [Route("dvds")]
        [AcceptVerbs("GET")]
        public IHttpActionResult All()
        {
            var repo = RepositoryFactory.GetMovieRepository();
            return Ok(repo.GetMovies());
        }

        [Route("dvd/{dvdId}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Get(int dvdId)
        {
            var repo = RepositoryFactory.GetMovieRepository();
            Movie movie = repo.GetMovieById(dvdId);
            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(movie);
            }
        }

        [Route("dvd/{dvdId}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult Delete(int dvdId)
        {
            var repo = RepositoryFactory.GetMovieRepository();
            Movie movie = repo.GetMovieById(dvdId);

            if (movie == null)
            {
                return NotFound();
            }

            repo.MovieDelete(dvdId);
            return Ok();
        }

        [Route("dvd/year/{releaseYear}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByYear(string releaseYear)
        {
            var repo = RepositoryFactory.GetMovieRepository();
            List<Movie> movie = repo.SearchByYear(releaseYear).ToList();
            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(movie);
            }
        }

        [Route("dvd/title/{title}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByTitle(string title)
        {
            var repo = RepositoryFactory.GetMovieRepository();
            List<Movie> movie = repo.SearchByTitle(title).ToList();
            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(movie);
            }
        }

        [Route("dvd/rating/{rating}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByRating(string rating)
        {
            var repo = RepositoryFactory.GetMovieRepository();
            List<Movie> movie = repo.SearchByRating(rating).ToList();
            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(movie);
            }
        }

        [Route("dvd/director/{director}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByDirector(string director)
        {
            var repo = RepositoryFactory.GetMovieRepository();
            List<Movie> movie = repo.SearchByDirector(director).ToList();
            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(movie);
            }
        }

        [Route("dvd")]
        [AcceptVerbs("POST")]
        public IHttpActionResult Add(AddMovieRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Movie movie = new Movie()
            {
                Title = request.Title,
                Rating = request.Rating,
                Director = request.Director,
                Notes = request.Notes,
                ReleaseYear = request.ReleaseYear

            };

            var repo = RepositoryFactory.GetMovieRepository();
            repo.MovieAdd(movie);
            return Created($"dvd/{movie.DvdId}", movie);
        }

        [Route("dvd/{movieId}")]
        [AcceptVerbs("PUT")]
        public IHttpActionResult Update(UpdateMovieRequest request)
        {
            var repo = RepositoryFactory.GetMovieRepository();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Movie movie = repo.GetMovieById(request.DvdId);

            if (movie == null)
            {
                return NotFound();
            }

            movie.Title = request.Title;
            movie.Rating = request.Rating;
            movie.ReleaseYear = request.ReleaseYear;
            movie.DvdId = request.DvdId;
            movie.Notes = request.Notes;
            movie.Director = request.Director;

            repo.MovieEdit(movie);
            return Ok(movie);
        }
    }
}