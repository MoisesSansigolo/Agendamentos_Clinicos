using Agendamentos_Clinicos.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agendamentos_Clinicos.Models.Dtos
{
    public class PacienteDetalheDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public List<ConsultaDto> Consultas { get; set; }
    }
}
