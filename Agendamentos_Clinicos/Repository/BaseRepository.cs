using Agendamentos_Clinicos.Context;
using Agendamentos_Clinicos.Repository.Interfaces;
using System;

namespace Agendamentos_Clinicos.Repository
{
    
    public class BaseRepository : IBaseRepository
    {
        private readonly AgendamentoContext _context;

        public BaseRepository(AgendamentoContext context)
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
