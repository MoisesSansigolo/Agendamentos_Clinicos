using Agendamentos_Clinicos.Context;
using Agendamentos_Clinicos.Models.Entities;
using Agendamentos_Clinicos.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agendamentos_Clinicos.Repository
{
    public class PacienteRepository :BaseRepository, IPacienteRepository
    {
        private readonly AgendamentoContext _context;

        public PacienteRepository(AgendamentoContext context) : base(context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Paciente> Get()
        {
            throw new NotImplementedException();
        }

        public Paciente GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
