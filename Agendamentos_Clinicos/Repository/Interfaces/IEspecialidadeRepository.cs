using Agendamentos_Clinicos.Models.Dtos;
using Agendamentos_Clinicos.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agendamentos_Clinicos.Repository.Interfaces
{
    public interface IEspecialidadeRepository : IBaseRepository
    {
        Task<IEnumerable<EspecialidadeDto>> GetAsync();
        Task<Especialidade> GetByIdAsync(int id);
    }
}
