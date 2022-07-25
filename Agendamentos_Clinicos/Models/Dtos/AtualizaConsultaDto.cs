using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agendamentos_Clinicos.Models.Dtos
{
    public class AtualizaConsultaDto
    {
        public DateTime DataHorario { get; set; }
        public int status { get; set; }
        public decimal Preco { get; set; }
        public int ProfissionalId { get; set; }
    }
}
