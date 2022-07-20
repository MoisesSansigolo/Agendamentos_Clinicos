using Agendamentos_Clinicos.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Agendamentos_Clinicos.Context
{
    public class AgendamentoContext : DbContext
    {
        public AgendamentoContext(DbContextOptions<AgendamentoContext> options) : base(options)
        {}

        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Especialidade> Especialidades { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Profissional> Profissionais { get; set; }
        public DbSet<ProfissionalEspecialidade> ProfissionalEspecialidades { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        }
    }
}
