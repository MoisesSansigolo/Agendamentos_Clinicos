using Agendamentos_Clinicos.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agendamentos_Clinicos.Repository.Interfaces
{
    public interface IPacienteRepository : IBaseRepository
    {
        Task<IEnumerable<Paciente>> GetAsync();
        Task<Paciente> GetByIdAsync(int id);
    }
}
