using DisneyAppParte2.Business.Services.MovieSerieService;
using DisneyAppParte2.Dtos.MovieSerieDtos;
using DisneyAppParte2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DisneyAppParte2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MovieSerieController : ControllerBase
    {
        private readonly IMovieSerieService _movieSerieService;
        public MovieSerieController(IMovieSerieService movieSerieService)
        {
            _movieSerieService = movieSerieService;
        }

        [HttpGet("details")]
        public async Task<ActionResult<MovieSerie>> GetDetails(int id)
        {
            var movieSeries = _movieSerieService.GetMovieSerieById(id);
            if (movieSeries == null)
                return new OkObjectResult("No se encontro");
            return movieSeries;
        }

        [HttpGet("movies")]
        public async Task<ActionResult<IEnumerable<GetMovieSerieDto>>> Get()
        {
            var movieSeries = _movieSerieService.Get();
            if (movieSeries == null)
                return new OkObjectResult("No se encontro");
            return movieSeries;
        }
        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<MovieSerie>>> GetFilter(string title, int idGenre, string order="asc")
        {
            var movieSeries = _movieSerieService.GetFilter(title,idGenre,order);
            if (movieSeries == null)
                return new OkObjectResult("No se encontro");
            return movieSeries;
        }

        [HttpPost]
        public async Task<ActionResult> PostMovie(CreateMovieSerieDto request, int idGenre, int characterId)
        {
            try
            {
                _movieSerieService.AddMovieSerie(request, idGenre, characterId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(request);
        }
        [HttpPut]
        public async Task<IActionResult> PutMovieSerie(int id, EditMovieSerieDto request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }
            try
            {
                _movieSerieService.EditMovieSerie(id, request);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new OkObjectResult(request);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMovieSerie(int id)
        {
            var movieSerie = _movieSerieService.GetMovieSerieComplete();
            if(movieSerie != null)
            {
                try
                {
                    var deleteFlag = _movieSerieService.DeleteMovieSerie(id);
                    if (!deleteFlag)
                        return NotFound();
                }
                catch(DbUpdateConcurrencyException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return new OkObjectResult(true);
            }
            return new OkObjectResult(false);
        }
    }
}
