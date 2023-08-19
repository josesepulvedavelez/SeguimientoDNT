using SeguimientoDNT.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguimientoDNT.Core.Interfaces
{
    public interface IPersonaRepository
    {
        Task<IEnumerable<Persona>> GetPersonas();
        Task<int> SetPersona(Persona persona);
        Task<byte[]> ExportarExcel();
    }
}
