using DisneyAppParte2.Dtos.CharacterDtos;
using DisneyAppParte2.Models;

namespace DisneyAppParte2.DataAccess.Repositories.CharacterRepository
{
    public interface ICharacterRepository
    {
        public List<Character> GetCharactersComplete();
        public Character GetCharacterById(int id);
        public void AddCharacter(CreateCharacterDto newCharacter);
        public EditCharacterDto EditCharacter(int id, EditCharacterDto updatedChar);
        public bool DeleteCharacter(int id);
    }
}
