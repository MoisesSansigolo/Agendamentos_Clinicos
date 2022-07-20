using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agendamentos_Clinicos.Models.Dtos
{
    public class ConsultaDto
    {
        public int Id { get; set; }
        public DateTime DataHoraio { get; set; }
        public int Status { get; set; }
        public decimal Preco { get; set; }
        public string Especialidade { get; set; }
        public string Profissional { get; set; }
    }
}
