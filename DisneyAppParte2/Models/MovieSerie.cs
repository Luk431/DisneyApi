using DataAnnotationsExtensions;
using System.Text.Json.Serialization;

namespace DisneyAppParte2.Models
{
    public class MovieSerie
    {
        public int Id { get; set; }
        public string Image { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        [Max(5)][Min(1)]
        public int Rate { get; set; } = 1;
        public List<Character> Characters { get; set; } = new List<Character>();
        public List<Genre> Genres { get; set; } = new List<Genre>();
        public int GenreId { get; set; }
    }
}