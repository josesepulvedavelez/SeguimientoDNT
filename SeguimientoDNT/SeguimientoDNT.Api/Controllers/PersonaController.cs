using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeguimientoDNT.Core.Dto;
using SeguimientoDNT.Core.Interfaces;
using SeguimientoDNT.Core.Models;
using SeguimientoDNT.Infra.Repositories;
using System.Net.Http;

namespace SeguimientoDNT.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaRepository _personaRepository;
        //private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;

        public PersonaController(IPersonaRepository personaRepository, IHttpClientFactory httpClientFactory)
        {
            _personaRepository = personaRepository;            
            _httpClientFactory = httpClientFactory;
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

        [HttpGet("ExportarExcel")]
        public async Task<IActionResult> ExportarExcel()
        {
            var excelData = await _personaRepository.ExportarExcel();

            return File(excelData, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "persona_seguimiento.xlsx");
        }


        [HttpGet("GetMunicipios")]
        public async Task<ActionResult> GetMunicipios()
        {
            var httpClient = _httpClientFactory.CreateClient("Cliente");

            var response = await httpClient.GetAsync("Municipio");
            var content = await response.Content.ReadAsStringAsync();

            return Ok(content);
        }

        [HttpGet("GetSexos")]
        public async Task<ActionResult> GetSexos()
        {
            var httpClient = _httpClientFactory.CreateClient("Cliente");

            var response = await httpClient.GetAsync("Sexo");
            var content = await response.Content.ReadAsStringAsync();

            return Ok(content);
        }

    }
}
