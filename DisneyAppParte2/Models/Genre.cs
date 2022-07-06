using System.Text.Json.Serialization;

namespace DisneyAppParte2.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        [JsonIgnore]
        public List<MovieSerie> MovieSeries { get; set; } = new List<MovieSerie>();
    }
}
