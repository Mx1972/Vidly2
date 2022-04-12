using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Vidly2.DTOs;
using Vidly2.Models;

namespace Vidly2.Controllers.API
{
    public class MoviesController: ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetMovies()
        {
            try
            {
                if (_context.Movies.Count() == 0)
                    return NotFound();

                return Ok(_context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        public IHttpActionResult GetMovieById(int id)
        {
            try
            {
                Movie movie = _context.Movies.SingleOrDefault(x => x.Id == id);
                if (movie == null)
                    return NotFound();

                return Ok(Mapper.Map<Movie, MovieDto>(movie));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]       
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                Movie movie = Mapper.Map<MovieDto, Movie>(movieDto);
                _context.Movies.Add(movie);
                _context.SaveChanges();

                movieDto.Id = movie.Id;

                return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
            }
            catch (Exception)
            {
                return InternalServerError(); 
            }
        }


        [HttpPut]
        public IHttpActionResult UpdateMovie(MovieDto movieDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                Movie movieInDb = _context.Movies.SingleOrDefault(x => x.Id == movieDto.Id);

                if (movieInDb == null)
                    return NotFound();

                Mapper.Map<MovieDto, Movie>(movieDto, movieInDb);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            try
            {
                if (!ModelState.IsValid || id <= 0)
                    return BadRequest("Invalid Movie Id, Movie Not Deleted");

                Movie movieInDb = _context.Movies.SingleOrDefault(x => x.Id == id);

                if (movieInDb == null)
                    return NotFound();

                _context.Movies.Remove(movieInDb);
                _context.SaveChanges();

                return Ok("Movie with id: " + movieInDb.Id + " and title: " + movieInDb.Title + " was deleted successfuly");
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}