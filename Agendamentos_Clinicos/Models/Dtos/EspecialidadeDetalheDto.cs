using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agendamentos_Clinicos.Models.Dtos
{
    public class EspecialidadeDetalheDto 
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativa { get; set; }
        public List<ProfissionalDto> Profissionais { get; set; }
    }
}
