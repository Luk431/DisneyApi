namespace DisneyAppParte2.Dtos.CharacterDtos
{
    public class CreateCharacterDto
    {
        public string Image { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public int Weight { get; set; }
        public string History { get; set; } = string.Empty;
        public int MovieSerieId { get; set; }
    }
}
