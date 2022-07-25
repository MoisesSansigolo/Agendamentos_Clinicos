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
    public class ConsultaRepository : BaseRepository, IConsultaRepository
    {
        private readonly AgendamentoContext _context;

        public ConsultaRepository(AgendamentoContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Consulta>> GetConsultas(ConsultaParams parametro)
        {
            var consultas = _context.Consultas
                .Include(x => x.Paciente)
                .Include(x => x.Profissional)
                .Include(x => x.Especialidade).AsQueryable();

            DateTime dataVazia = new DateTime();
            if (parametro.DataInicio != dataVazia)
            {
                consultas = consultas.Where(x => x.DataHorario >= parametro.DataInicio);
            } if (parametro.DataFim != dataVazia)

            {
                consultas = consultas.Where(x => x.DataHorario <= parametro.DataFim);
            }

            return await consultas.ToListAsync();
        }
      
        public async Task<Consulta> GetConsultasById(int id)
        {
            return await _context.Consultas
                .Include(x => x.Paciente)
                .Include(x => x.Profissional)
                .Include(x => x.Especialidade)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
