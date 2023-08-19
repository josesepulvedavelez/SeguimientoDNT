using Microsoft.EntityFrameworkCore;
using SeguimientoDNT.Core.Interfaces;
using SeguimientoDNT.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguimientoDNT.Infra.Repositories
{
    public class SeguimientoRepository : ISeguimientoRepository
    {
        private readonly SeguimientoDntConext _seguimientoDntConext;

        public SeguimientoRepository(SeguimientoDntConext seguimientoDntConext)
        {
            _seguimientoDntConext = seguimientoDntConext;
        }

        public async Task<IEnumerable<Seguimiento>> GetSeguimientos(int idPersona)
        {
            var result = await (from s in _seguimientoDntConext.Seguimiento
                         where s.IdPersona == idPersona
                         select s).ToListAsync();

            return result;
        }

        public async Task<int> SetSeguimiento(Seguimiento seguimiento)
        {
            await _seguimientoDntConext.Seguimiento.AddAsync(seguimiento);
            var result = await _seguimientoDntConext.SaveChangesAsync();

            return result;
        }
    }
}
