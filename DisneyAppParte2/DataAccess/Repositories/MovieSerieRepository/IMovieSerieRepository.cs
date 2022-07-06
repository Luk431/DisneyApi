using DisneyAppParte2.Dtos.MovieSerieDtos;
using DisneyAppParte2.Models;

namespace DisneyAppParte2.DataAccess.Repositories.MovieSerieRepository
{
    public interface IMovieSerieRepository
    {
        public List<MovieSerie> GetMovieSerieComplete();
        public MovieSerie GetMovieSerieById(int id);
        public List<MovieSerie> GetByGenre(int idGenre);
        public void AddMovieSerie(CreateMovieSerieDto newMovieSerie, int idGenre, int characterId);
        public EditMovieSerieDto EditMovieSerie(int id, EditMovieSerieDto updateMovie);
        public bool DeleteMovieSerie(int id);
    }
}
