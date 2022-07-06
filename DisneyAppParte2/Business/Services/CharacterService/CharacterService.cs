using DisneyAppParte2.DataAccess.Repositories.CharacterRepository;
using DisneyAppParte2.Dtos.CharacterDtos;
using DisneyAppParte2.Models;

namespace DisneyAppParte2.Business.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _characterRepository;
        public CharacterService(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public List<Character> GetCharacters()
        {
            return _characterRepository.GetCharactersComplete();
        }
        public List<Character> GetDetails(int characterId)
        {
            return _characterRepository.GetCharactersComplete().Where(c=>c.Id == characterId).ToList();
        }
        public List<Character> GetFilter(string name, int age, int weigth, int idMovie)
        {
            if(name.ToLower() == null)
                throw new ArgumentNullException("the name can´t be null");
            if(age != 0)
                return GetByAge(age).Where(c => c.Name.ToLower() == name).ToList();
            if (weigth != 0)
                return GetByWeight(weigth).Where(c => c.Name.ToLower() == name).ToList();
            if (idMovie != 0)
                return GetByMovie(idMovie).Where(c => c.Name.ToLower() == name).ToList();

            throw new ArgumentNullException("one or more invalid arguments");
        }

        public List<CharacterNameImageDto> GetAll()
        {
            List<CharacterNameImageDto> charlist = new List<CharacterNameImageDto>();
            var characters = _characterRepository.GetCharactersComplete();
            foreach(var c in characters)
            {
                charlist.Add(new CharacterNameImageDto { Image = c.Image, Name = c.Name });
            }
            return charlist;
        }
        public List<Character> GetByName(string name)
        {
            return _characterRepository.GetCharactersComplete().Where(c => c.Name == name).ToList();
        }
        public List<Character> GetByAge(int age)
        {
            return _characterRepository.GetCharactersComplete().Where(c => c.Age == age).ToList();
        }
        public List<Character> GetByWeight(int weight)
        {
            return _characterRepository.GetCharactersComplete().Where(c => c.Weight == weight).ToList();
        }
        public List<Character> GetByMovie(int idMovie)
        {
            return _characterRepository.GetCharactersComplete().Where(c => c.MovieSerieId == idMovie).ToList();
        }
        public void AddCharacter(CreateCharacterDto newCharacter)
        {
            _characterRepository.AddCharacter(newCharacter);
        }
        public EditCharacterDto EditCharacter(int id, EditCharacterDto updatedChar)
        {
            return _characterRepository.EditCharacter(id, updatedChar);
        }
        public bool DeleteCharacter(int id)
        {
            return _characterRepository.DeleteCharacter(id);
        }
    }
}
