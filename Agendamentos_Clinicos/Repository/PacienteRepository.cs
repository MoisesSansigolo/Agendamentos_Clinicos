using Agendamentos_Clinicos.Context;
using Agendamentos_Clinicos.Models.Dtos;
using Agendamentos_Clinicos.Models.Entities;
using Agendamentos_Clinicos.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agendamentos_Clinicos.Repository
{
    public class PacienteRepository : BaseRepository, IPacienteRepository
    {
        private readonly AgendamentoContext _context;

        public PacienteRepository(AgendamentoContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PacienteDto>> GetAsync() //busca todos os pacientes
        {
            var paciente =await _context.Pacientes.Select(x => new PacienteDto { Id = x.Id, Nome = x.Nome }).ToListAsync();
            return paciente;
        }

        public async Task<Paciente> GetByIdAsync(int id) //Busca paciente por ID
        {
            var pacienteId =await _context.Pacientes.Include(x => x.Consultas)
                .ThenInclude(c => c.Especialidade)
                .ThenInclude(p => p.Profissionais)
                .Where(x => x.Id == id).FirstOrDefaultAsync();
            return (pacienteId);
        }

        
    }
}