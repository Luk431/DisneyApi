using System.Text.Json.Serialization;

namespace DisneyAppParte2.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Image { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public int Weight { get; set; }
        public string History { get; set; } = string.Empty;
        [JsonIgnore]
        public MovieSerie? MovieSerie { get; set; }
        //Foreing Key(MovieSerieID)
        public int MovieSerieId { get; set; }
    }
}
