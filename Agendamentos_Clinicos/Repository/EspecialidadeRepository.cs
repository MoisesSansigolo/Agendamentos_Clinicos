using Agendamentos_Clinicos.Context;
using Agendamentos_Clinicos.Models.Dtos;
using Agendamentos_Clinicos.Models.Entities;
using Agendamentos_Clinicos.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agendamentos_Clinicos.Repository
{
    public class EspecialidadeRepository : BaseRepository, IEspecialidadeRepository
    {
        private readonly AgendamentoContext _context;

        public EspecialidadeRepository(AgendamentoContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<EspecialidadeDto>> GetAsync()
        {
            return await _context.Especialidades
                .Select(x => new EspecialidadeDto { Id = x.Id, Nome = x.Nome, Ativa = x.Ativa }).ToListAsync();
        }

        public async Task<Especialidade> GetByIdAsync(int id)
        {
            return await _context.Especialidades
                .Include(x => x.Profissionais)
                .Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
