
using Clinica.Domains;
using Microsoft.EntityFrameworkCore;


namespace Clinica.Persistence
{
    public class ClinicaDB : DbContext
    {
        public ClinicaDB(DbContextOptions<ClinicaDB> opts) : base(opts) 
        {}

        public DbSet<Doctor> Doctores { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Consulta> Consultas { get; set; }

    }
}
