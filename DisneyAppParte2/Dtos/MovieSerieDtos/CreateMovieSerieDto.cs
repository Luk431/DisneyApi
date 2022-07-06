using DataAnnotationsExtensions;

namespace DisneyAppParte2.Dtos.MovieSerieDtos
{
    public class CreateMovieSerieDto
    {
        public string Image { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        [Max(5)]
        [Min(1)]
        public int Rate { get; set; } = 1;
        public int GenreId { get; set; }
        public int CharacterId { get; set; }
    }
}
