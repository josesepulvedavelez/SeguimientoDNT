using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeguimientoDNT.Core.Interfaces;
using SeguimientoDNT.Core.Models;
using SeguimientoDNT.Infra.Repositories;

namespace SeguimientoDNT.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeguimientoController : ControllerBase
    {
        private readonly ISeguimientoRepository _seguimientoRepository;

        public SeguimientoController(ISeguimientoRepository seguimientoRepository)
        {
            _seguimientoRepository = seguimientoRepository;
        }

        [HttpGet("GetSeguimientos/{idPersona}")]
        public async Task<IEnumerable<Seguimiento>> GetSeguimientos(int idPersona)
        {
            var lst = await _seguimientoRepository.GetSeguimientos(idPersona);
            return lst;
        }

        [HttpPost("SetSeguimiento")]
        public async Task<int> SetSeguimiento(Seguimiento seguimiento)
        {
            var fechaHora = DateTime.Now;
            seguimiento.FechaRegistro = fechaHora;

            var result = await _seguimientoRepository.SetSeguimiento(seguimiento);
            return result;
        }

    }
}
