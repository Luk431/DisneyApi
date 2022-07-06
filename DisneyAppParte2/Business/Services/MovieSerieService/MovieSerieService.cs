using DisneyAppParte2.DataAccess.Repositories.MovieSerieRepository;
using DisneyAppParte2.Dtos.MovieSerieDtos;
using DisneyAppParte2.Models;

namespace DisneyAppParte2.Business.Services.MovieSerieService
{
    public class MovieSerieService : IMovieSerieService
    {
        private readonly IMovieSerieRepository _movieSerieRepository;
        public MovieSerieService(IMovieSerieRepository movieSerieRepository)
        {
            _movieSerieRepository = movieSerieRepository;
        }

        public List<MovieSerie> GetMovieSerieComplete()
        {
            return _movieSerieRepository.GetMovieSerieComplete();
        }
        public List<GetMovieSerieDto> Get()
        {
            var movies = _movieSerieRepository.GetMovieSerieComplete();
            List<GetMovieSerieDto> list = new List<GetMovieSerieDto>();
            foreach(var movie in movies)
            {
                list.Add(new GetMovieSerieDto { Title = movie.Title, Image = movie.Image, CreationDate = movie.CreationDate });
            }
            return list;
        }
        public List<MovieSerie> GetFilter(string title, int idGenre, string order="ASC")
        {
            if (title.ToLower() == null)
                throw new ArgumentNullException("the title can´t be null");
            if (idGenre != 0)
                switch (order.ToLower())
                {
                    case "asc":
                            return GetMovieByGenre(idGenre).Where(m => m.Title.ToLower() == title).OrderBy(m => m.CreationDate).ToList();
                        break;
                    case "desc":
                            return GetMovieByGenre(idGenre).Where(m => m.Title.ToLower() == title).OrderByDescending(m => m.CreationDate).ToList();
                        break;
                    default:
                        throw new ArgumentException("failder to order. Try using ASC | DESC");
                }
            throw new ArgumentNullException("one or more invalid arguments");
        }
        public MovieSerie GetMovieSerieById(int id)
        {
            return _movieSerieRepository.GetMovieSerieById(id);
        }
        public List<MovieSerie> GetMovieByName(string title)
        {
            return _movieSerieRepository.GetMovieSerieComplete().Where(m => m.Title == title).ToList();
        }
        public List<MovieSerie> GetMovieByGenre(int idGenre)
        {
            return _movieSerieRepository.GetByGenre(idGenre).ToList();
        }
        public List<MovieSerie> GetOrderByASC()
        {
            return _movieSerieRepository.GetMovieSerieComplete().OrderBy(m => m.CreationDate).ToList();
        }
        public List<MovieSerie> GetOrderByDESC()
        {
            return _movieSerieRepository.GetMovieSerieComplete().OrderByDescending(m => m.CreationDate).ToList();
        }
        public void AddMovieSerie(CreateMovieSerieDto newMovieSerie, int idGenre, int characterId)
        {
            _movieSerieRepository.AddMovieSerie(newMovieSerie, idGenre, characterId);
        }
        public EditMovieSerieDto EditMovieSerie(int id, EditMovieSerieDto updatedChar)
        {
            return _movieSerieRepository.EditMovieSerie(id, updatedChar);
        }
        public bool DeleteMovieSerie(int id)
        {
            return _movieSerieRepository.DeleteMovieSerie(id);
        }
    }
}
