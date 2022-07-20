using Agendamentos_Clinicos.Models.Dtos;
using Agendamentos_Clinicos.Models.Entities;
using Agendamentos_Clinicos.Repository.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Agendamentos_Clinicos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteRepository _repository;
        private readonly IMapper _mapper;

        public PacienteController(IPacienteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var pacientes = await _repository.GetAsync();

            return pacientes.Any()
                ? Ok(pacientes)
                : BadRequest("Paciente não registrado");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pacienteId = await _repository.GetByIdAsync(id);

            var pacienteRetorno = _mapper.Map<PacienteDetalheDto>(pacienteId);

            if (pacienteRetorno != null)
            {
                return Ok(pacienteRetorno);
            }else
            {
                return BadRequest("Paciente não Agendado");        
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(AdicionarPacienteDto paciente)
        {
            if (paciente == null) return BadRequest("Dados Invalidos");

            var adicionarPaciente = _mapper.Map<Paciente>(paciente);

            _repository.Add(adicionarPaciente);

            return await _repository.SaveChangesAsync()
                ? Ok("Paciente agendado com sucesso")
                : BadRequest("Erro ao agendar o paciente");                   

        }
    }         
}
