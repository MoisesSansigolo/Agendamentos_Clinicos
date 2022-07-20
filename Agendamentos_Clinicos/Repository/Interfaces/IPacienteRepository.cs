using Agendamentos_Clinicos.Models.Dtos;
using Agendamentos_Clinicos.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agendamentos_Clinicos.Repository.Interfaces
{
    public interface IPacienteRepository : IBaseRepository
    {
        Task<IEnumerable<PacienteDto>> GetAsync();
        Task<Paciente> GetByIdAsync(int id);
    }
}
