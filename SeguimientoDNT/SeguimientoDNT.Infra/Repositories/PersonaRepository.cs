using ClosedXML.Excel;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.EntityFrameworkCore;
using SeguimientoDNT.Core.Dto;
using SeguimientoDNT.Core.Interfaces;
using SeguimientoDNT.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SeguimientoDNT.Infra.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly SeguimientoDntConext _seguimientoDntConext;

        public PersonaRepository(SeguimientoDntConext seguimientoDntConext)
        {
            _seguimientoDntConext = seguimientoDntConext;
        }

        public async Task<byte[]> ExportarExcel()
        {
            var personaSeguimientoList = await (from p in _seguimientoDntConext.Persona
                                                join s in _seguimientoDntConext.Seguimiento
                                                on p.IdPersona equals s.IdPersona
                                                select new PersonaSeguimientoDto
                                                {
                                                    IdPersona = p.IdPersona,
                                                    TipoIdentificacion = p.TipoIdentificacion,
                                                    NroIdentificacion = p.NroIdentificacion,
                                                    PrimerNombre = p.PrimerNombre,
                                                    SegundoNombre = p.SegundoNombre,
                                                    PrimerApellido = p.PrimerApellido,
                                                    SegundoApellido = p.SegundoApellido,
                                                    Sexo = p.Sexo,
                                                    FechaNacimiento = p.FechaNacimiento,
                                                    CodMpioResidencia = p.CodMpioResidencia,
                                                    CodAsegurador = p.CodAsegurador,
                                                    fechaRegistro = p.fechaRegistro,

                                                    IdSeguimiento = s.IdSeguimiento,
                                                    EstadoVital = s.EstadoVital,
                                                    FechaDefuncion = s.FechaDefuncion,
                                                    UbicacionDefuncion = s.UbicacionDefuncion,
                                                    CodLugarAtencion = s.CodLugarAtencion,
                                                    FechaAtencion = s.FechaAtencion,
                                                    PesoKg = s.PesoKg,
                                                    TallaCm = s.TallaCm,
                                                    CodClasificacionNutricional = s.CodClasificacionNutricional,
                                                    CodManejoActual = s.CodManejoActual,
                                                    DesManejo = s.DesManejo,
                                                    CodUbicacion = s.CodUbicacion,
                                                    DesUbicacion = s.DesUbicacion,
                                                    CodTratamiento = s.CodTratamiento,
                                                    TotalSobresFTLC = s.TotalSobresFTLC,
                                                    OtroTratamiento = s.OtroTratamiento,
                                                    FechaRegistro = s.FechaRegistro
                                                }).ToListAsync();


            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("PersonaSeguimiento");

                var headerRow = worksheet.Row(1);
                int col = 1;
                foreach (var prop in typeof(PersonaSeguimientoDto).GetProperties())
                {
                    headerRow.Cell(col).Value = prop.Name;
                    col++;
                }
                                
                int row = 2;
                foreach (var personaSeguimiento in personaSeguimientoList)
                {
                    col = 1;
                    foreach (var prop in typeof(PersonaSeguimientoDto).GetProperties())
                    {
                        var propValue = prop.GetValue(personaSeguimiento);

                        if (propValue == null)
                        {
                            worksheet.Cell(row, col).Value = string.Empty;
                        }
                        else if (prop.PropertyType == typeof(DateTime?))
                        {
                            worksheet.Cell(row, col).Value = ((DateTime?)propValue)?.ToString("yyyy-MM-dd");
                        }
                        else if (prop.PropertyType == typeof(decimal?))
                        {
                            worksheet.Cell(row, col).Value = (decimal?)propValue;
                        }
                        else
                        {
                            worksheet.Cell(row, col).Value = propValue.ToString();
                        }

                        col++;
                    }
                    row++;
                }


                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    stream.Seek(0, SeekOrigin.Begin);
                    return stream.ToArray();
                }
            }
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
