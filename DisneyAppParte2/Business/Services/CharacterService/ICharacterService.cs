using DisneyAppParte2.Dtos.CharacterDtos;
using DisneyAppParte2.Models;

namespace DisneyAppParte2.Business.Services.CharacterService
{
    public interface ICharacterService
    {
        public List<Character> GetCharacters();
        public List<Character> GetDetails(int characterId);
        public List<Character> GetFilter(string name, int age, int weigth, int idMovie);
        public List<CharacterNameImageDto> GetAll();
        public List<Character> GetByName(string name);
        public List<Character> GetByAge(int age);
        public List<Character> GetByWeight(int weight);
        public List<Character> GetByMovie(int idMovie);
        public void AddCharacter(CreateCharacterDto newCharacter);
        public EditCharacterDto EditCharacter(int id, EditCharacterDto updatedChar);
        public bool DeleteCharacter(int id);
    }
}
