using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agendamentos_Clinicos.Models.Dtos
{
    public class AdicionarConsultaDto
    {
        public DateTime DataHorario { get; set; }
        public int Status { get; set; }
        public decimal Preco { get; set; }
        public int PacienteId { get; set; }
        public int EspecialidadeId { get; set; }
        public int ProfissionalId { get; set; }
    }
}
