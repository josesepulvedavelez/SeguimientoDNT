using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeguimientoDNT.Core.Interfaces;
using SeguimientoDNT.Core.Models;
using SeguimientoDNT.Infra.Repositories;

namespace SeguimientoDNT.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaRepository _personaRepository;

        public PersonaController(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }

        [HttpGet("GetPersonas")]
        public async Task<IEnumerable<Persona>> GetPersonas()
        {
            var lst = await _personaRepository.GetPersonas();
            return lst;
        }

        [HttpPost("SetPersona")]
        public async Task<int> SetPersona(Persona persona)
        {
            var fechaHora = DateTime.Now;
            persona.fechaRegistro = fechaHora;

            var result = await _personaRepository.SetPersona(persona);
            return result;
        }

    }
}
