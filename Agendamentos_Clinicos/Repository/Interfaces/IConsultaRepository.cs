using Agendamentos_Clinicos.Models.Dtos;
using Agendamentos_Clinicos.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agendamentos_Clinicos.Repository.Interfaces
{
    public interface IConsultaRepository : IBaseRepository
    {
        Task<IEnumerable<Consulta>> GetConsultas(ConsultaParams parametro);
        Task<Consulta> GetConsultasById(int id);
    }
}
