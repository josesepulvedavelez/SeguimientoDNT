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
    public class PersonaRepository : IPersonaRepository
    {
        private readonly SeguimientoDntConext _seguimientoDntConext;

        public PersonaRepository(SeguimientoDntConext seguimientoDntConext)
        {
            _seguimientoDntConext = seguimientoDntConext;
        }

        public async Task<IEnumerable<Persona>> GetPersonas()
        {
            return await _seguimientoDntConext.Persona.ToListAsync();    
        }

        public async Task<int> SetPersona(Persona persona)
        {
            await _seguimientoDntConext.Persona.AddAsync(persona);
            var result = await _seguimientoDntConext.SaveChangesAsync();

            return result;
        }

    }
}
