using SeguimientoDNT.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguimientoDNT.Core.Interfaces
{
    public interface ISeguimientoRepository
    {
        Task<IEnumerable<Seguimiento>> GetSeguimientos(int idPersona);
        Task<int> SetSeguimiento(Seguimiento seguimiento);    
    }
}
