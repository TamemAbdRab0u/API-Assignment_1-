using API_Assignment_1_.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Assignment_1_.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly AppDbContext context;
        public MovieController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<Movie> movies = context.Movies.ToList();
            return Ok(movies);
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult GetById(int Id)
        {
            Movie movie = context.Movies.FirstOrDefault(x => x.Id == Id);
            if(movie != null)
            {
                return Ok(movie);
            }
            else
            {
                return NotFound("Movie Was Not Found");
            }
        }

        [HttpPost]
        [Route("")]
        public IActionResult Add(Movie movie)
        {
            context.Movies.Add(movie);
            context.SaveChanges();
            return Ok($"New Movie [{movie.Title}] Added Successfully");
            //return CreatedAtAction(nameof(GetById), new { Id = movie.Id }, movie);
        }

        [HttpPut]
        [Route("")]
        public IActionResult Update(Movie movie)
        {
            var OldMovie = context.Movies.FirstOrDefault(x => x.Id == movie.Id);
            OldMovie.Title = movie.Title;
            OldMovie.Director = movie.Director;
            OldMovie.ReleaseYear = movie.ReleaseYear;

            context.Movies.Update(OldMovie);
            context.SaveChanges();
            return Ok($"Movie [{OldMovie.Title}] Updated Successfully");
        }

        [HttpDelete]
        [Route("{Id}")]
        public IActionResult Delete(int Id)
        {
            var movie = context.Movies.FirstOrDefault( x => x.Id == Id);
            if (movie != null)
            {
                context.Movies.Remove(movie);
                context.SaveChanges();
                return Ok($"Movie [{movie.Title}] Has Been Deleted");
            }
            else
            {
                return NotFound("Movie Was Not Found");
            }
        }
    }
}
