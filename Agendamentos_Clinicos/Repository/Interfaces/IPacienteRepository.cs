using Agendamentos_Clinicos.Models.Entities;
using System.Collections.Generic;

namespace Agendamentos_Clinicos.Repository.Interfaces
{
    public interface IPacienteRepository : IBaseRepository
    {
        IEnumerable<Paciente> Get();
        Paciente GetById(int id);
    }
}
