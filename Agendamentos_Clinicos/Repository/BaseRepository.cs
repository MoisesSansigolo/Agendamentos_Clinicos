using Agendamentos_Clinicos.Context;
using Agendamentos_Clinicos.Repository.Interfaces;
using System;
using System.Threading.Tasks;

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
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
