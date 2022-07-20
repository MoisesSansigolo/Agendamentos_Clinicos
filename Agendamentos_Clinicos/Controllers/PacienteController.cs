using Agendamentos_Clinicos.Models.Entities;
using Agendamentos_Clinicos.Repository.Interfaces;
using Agendamentos_Clinicos.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agendamentos_Clinicos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteRepository _repository;

        public PacienteController(IPacienteRepository repository)
        {
            _repository = repository;
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
            if (pacienteId != null)
            {
                return Ok(pacienteId);
            }else
            {
                return BadRequest("Paciente não ")
            }
        }
    }
}
