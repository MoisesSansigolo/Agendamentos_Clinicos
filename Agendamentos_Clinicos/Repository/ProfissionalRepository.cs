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
    public class ProfissionalRepository : BaseRepository, IProfissionalRepository
    {
        private readonly AgendamentoContext _context;

        public ProfissionalRepository(AgendamentoContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ProfissionalDto>> Get()
        {
            return await  _context.Profissionais.Select(x => new ProfissionalDto 
                { Id = x.Id, Nome = x.Nome, Ativo = x.Ativo}).ToListAsync();           
                
        }

        public async Task<Profissional> GetByIdAsync(int id)
        {
            return await _context.Profissionais
                .Include(x => x.Consultas)
                .Include(x => x.Especialidades)
                .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ProfissionalEspecialidade> GetProfEspec(int profissionalId, int especialidadeId)
        {
            return await _context.ProfissionalEspecialidades
                .Where(x => x.ProfissionalId == profissionalId && x.EspecialidadeId == especialidadeId)
                .FirstOrDefaultAsync();
        }
    }
}
