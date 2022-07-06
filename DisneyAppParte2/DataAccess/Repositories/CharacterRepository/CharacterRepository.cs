using DisneyAppParte2.DataAccess.Data;
using DisneyAppParte2.Dtos.CharacterDtos;
using DisneyAppParte2.Models;
using Microsoft.AspNetCore.Mvc;

namespace DisneyAppParte2.DataAccess.Repositories.CharacterRepository
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly DisneyAppDbContext _context;
        public CharacterRepository(DisneyAppDbContext context)
        {
            _context = context;
        }
        public List<Character> GetCharactersComplete()
        {
            var movies = _context.MovieSerie.ToList();
            return _context.Character.ToList();
        }

        public Character? GetCharacterById(int id)
        {
            return _context.Character.Find(id);
        }

        public void AddCharacter(CreateCharacterDto newCharacter)
        {
            var movies = _context.MovieSerie.ToList();
            try
            {
                Character character = new Character()
                {
                    Name = newCharacter.Name,
                    Age = newCharacter.Age,
                    History = newCharacter.History,
                    Image = newCharacter.Image,
                    MovieSerieId = newCharacter.MovieSerieId,
                    Weight = newCharacter.Weight
                };
                _context.Character.Add(character);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public EditCharacterDto EditCharacter(int id, EditCharacterDto updatedChar)
        {
            var oldChar = GetCharacterById(id);
            if(oldChar != null && oldChar.Id == updatedChar.Id)
            {
                oldChar.Image = updatedChar.Image;
                oldChar.Name = updatedChar.Name;
                oldChar.Age = updatedChar.Age;
                oldChar.Weight = updatedChar.Weight;
                oldChar.History = updatedChar.History;
                oldChar.MovieSerieId = updatedChar.MovieSerieId;
                try
                {
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return updatedChar;
        }
        public bool DeleteCharacter(int id)
        {
            var character = GetCharacterById(id);
            if(character != null)
            {
                try
                {
                    _context.Character.Remove(character);
                    _context.SaveChanges();
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                return true;
            }
            return false;
        }
    }
}
