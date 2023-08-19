using Microsoft.EntityFrameworkCore;
using SeguimientoDNT.Core.Models;

namespace SeguimientoDNT.Infra
{
    public class SeguimientoDntConext : DbContext
    {
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Seguimiento> Seguimiento { get; set; }

        public SeguimientoDntConext(DbContextOptions<SeguimientoDntConext> options) : base(options)
        { 
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Seguimiento>()
                .HasOne(s => s.Persona)
                .WithMany(p => p.Seguimiento)
                .HasForeignKey(s => s.IdPersona);
        }

    }
}