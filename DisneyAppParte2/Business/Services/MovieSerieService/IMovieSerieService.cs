using DisneyAppParte2.Dtos.MovieSerieDtos;
using DisneyAppParte2.Models;

namespace DisneyAppParte2.Business.Services.MovieSerieService
{
    public interface IMovieSerieService
    {
        public List<MovieSerie> GetMovieSerieComplete();
        public List<GetMovieSerieDto> Get();
        public List<MovieSerie> GetFilter(string title, int idGenre, string order = "asc");
        public List<MovieSerie> GetMovieByName(string title);
        public List<MovieSerie> GetMovieByGenre(int idGenre);
        public List<MovieSerie> GetOrderByASC();
        public List<MovieSerie> GetOrderByDESC();
        public MovieSerie GetMovieSerieById(int id);
        public void AddMovieSerie(CreateMovieSerieDto newMovieSerie, int idGenre, int characterId);
        public EditMovieSerieDto EditMovieSerie(int id, EditMovieSerieDto updatedChar);
        public bool DeleteMovieSerie(int id);
    }
}
