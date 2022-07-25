using Agendamentos_Clinicos.Context;
using Agendamentos_Clinicos.Models.Entities;
using Agendamentos_Clinicos.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agendamentos_Clinicos.Repository
{
    public class AgendamentoRepository : BaseRepository, IAgendamentoRepository
    {
        private readonly AgendamentoContext _context;

        public AgendamentoRepository(AgendamentoContext context) : base (context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Consulta>> GetAgendamentos()
        {
            return await _context.Consultas
                .Include(x => x.Paciente)
                .Include(x => x.Profissional)
                .Include(x => x.Especialidade)
                .ToListAsync();
        }
        public async Task<Consulta> GetAgendamentoById(int id)
        {
            return await _context.Consultas
                .Include(x => x.PacienteId)
                .Include(x => x.ProfissionalId)
                .Include(x => x.EspecialidadeId)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

        }
    }
}
