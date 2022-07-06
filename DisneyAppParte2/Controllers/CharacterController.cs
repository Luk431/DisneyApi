using DisneyAppParte2.Business.Services.CharacterService;
using DisneyAppParte2.Dtos.CharacterDtos;
using DisneyAppParte2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DisneyAppParte2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet("details")]
        public async Task<ActionResult<IEnumerable<Character>>> GetDetails(int characterId)
        {
            var characters = _characterService.GetDetails(characterId);
            if (characters == null)
                return new NotFoundObjectResult("no existen");
            return new OkObjectResult(characters);
        }

        [HttpGet("characters")]
        public async Task<ActionResult<IEnumerable<CharacterNameImageDto>>> GetNameImage()
        {
            var characters = _characterService.GetAll();
            if (characters == null)
                return new NotFoundObjectResult("no existen");
            return new OkObjectResult(characters);
        }
        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<Character>>> GetByName(string name, int age, int weigth, int idMovie)
        {
            var character = _characterService.GetFilter(name,age ,weigth,idMovie);
            if (character == null)
                return new OkObjectResult("no existe");
            return character;
        }

        [HttpPost]
        public async Task<ActionResult> PostCharacter(CreateCharacterDto newCharacter)
        {
            try
            {
                _characterService.AddCharacter(newCharacter);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return Ok(newCharacter);
        }

        [HttpPut]
        public async Task<IActionResult> PutCharacter(int id, EditCharacterDto request)
        {
            if(id != request.Id)
            {
                return BadRequest();
            }
            try
            {
                _characterService.EditCharacter(id, request);
            }
            catch(DbUpdateConcurrencyException ex)
            {
                throw ex;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return new OkObjectResult(request);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteChar(int id)
        {
            var characters = _characterService.GetCharacters();
            if (characters == null)
                return NotFound();
            try
            {
                var deleteFlag = _characterService.DeleteCharacter(id);
                if (!deleteFlag)
                {
                    return NotFound();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return new OkObjectResult(true);
        }
    }
}
