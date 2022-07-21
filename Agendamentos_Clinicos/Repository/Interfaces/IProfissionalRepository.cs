using Agendamentos_Clinicos.Models.Dtos;
using Agendamentos_Clinicos.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agendamentos_Clinicos.Repository.Interfaces
{
    public interface IProfissionalRepository : IBaseRepository
    {
        Task<IEnumerable<ProfissionalDto>> Get();
        Task<Profissional> GetByIdAsync(int id);
    }
}
