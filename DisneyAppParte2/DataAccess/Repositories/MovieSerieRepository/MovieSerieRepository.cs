using DisneyAppParte2.DataAccess.Data;
using DisneyAppParte2.Dtos.MovieSerieDtos;
using DisneyAppParte2.Models;

namespace DisneyAppParte2.DataAccess.Repositories.MovieSerieRepository
{
    public class MovieSerieRepository : IMovieSerieRepository
    {
        private readonly DisneyAppDbContext _context;
        public MovieSerieRepository(DisneyAppDbContext context)
        {
            _context = context;
        }

        public List<MovieSerie> GetMovieSerieComplete()
        {
            var character = _context.Character.ToList();
            var genre = _context.Genre.ToList();
            return _context.MovieSerie.Include(g=>g.Genres).ToList();
        }
        public MovieSerie? GetMovieSerieById(int id)
        {
            return _context.MovieSerie.Find(id);
        }
        public List<MovieSerie> GetByGenre(int idGenre)
        {
            var movies = GetMovieSerieComplete();
            return movies.Where(m => m.GenreId == idGenre).ToList();
        }
        public void AddMovieSerie(CreateMovieSerieDto newMovieSerie, int genreId, int characterId)
        {
            var characters = _context.Character.ToList();
            var character = characters.Where(c => c.Id == characterId).ToList();
            var genres = _context.Genre.ToList();
            var genre = _context.Genre.Where(g => g.Id == genreId).ToList();

            try
            {
                MovieSerie movies = new MovieSerie()
                {
                    Rate = newMovieSerie.Rate,
                    CreationDate = newMovieSerie.CreationDate,
                    Title = newMovieSerie.Title,
                    Image = newMovieSerie.Image,
                    Genres = genre.ToList(),
                    Characters = character.ToList(),
                    GenreId = newMovieSerie.GenreId
                };
                _context.MovieSerie.Add(movies);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public EditMovieSerieDto EditMovieSerie(int id, EditMovieSerieDto updateMovie)
        {
            var oldMovie = GetMovieSerieById(id);
            if(oldMovie != null && oldMovie.Id == updateMovie.Id)
            {
                oldMovie.Title = updateMovie.Title;
                oldMovie.Rate = updateMovie.Rate;
                oldMovie.Image = updateMovie.Image;
                oldMovie.CreationDate = updateMovie.CreationDate;
                oldMovie.GenreId = updateMovie.GenreId;
                try
                {
                    _context.SaveChanges();
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
            return updateMovie;
        }
        public bool DeleteMovieSerie(int id)
        {
            var movieSerie = GetMovieSerieById(id);
            if (movieSerie != null)
            {
                try
                {
                    _context.MovieSerie.Remove(movieSerie);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return true;
            }
            return false;
        }
    }
}
