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
    public class PacienteRepository : BaseRepository, IPacienteRepository
    {
        private readonly AgendamentoContext _context;

        public PacienteRepository(AgendamentoContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Paciente>> GetAsync() //busca todos os pacientes
        {
            var paciente =await _context.Pacientes.Include(x => x.Consultas).ToListAsync();
            return paciente;
        }

        public async Task<Paciente> GetByIdAsync(int id) //Busca paciente por ID
        {
            var pacienteId =await _context.Pacientes.Include(x => x.Consultas).Where(x => x.Id == id).FirstOrDefaultAsync();
            return (pacienteId);
        }

        
    }
}