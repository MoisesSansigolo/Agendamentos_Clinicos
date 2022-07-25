using Agendamentos_Clinicos.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agendamentos_Clinicos.Repository.Interfaces
{
    interface IAgendamentoRepository : IBaseRepository
    {
        public Task<IEnumerable<Consulta>> GetAgendamentos();
        Task<Consulta> GetAgendamentoById(int id);
    }
}
