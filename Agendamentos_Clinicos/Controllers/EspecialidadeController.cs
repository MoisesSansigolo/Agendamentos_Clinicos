using Agendamentos_Clinicos.Models.Dtos;
using Agendamentos_Clinicos.Models.Entities;
using Agendamentos_Clinicos.Repository.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agendamentos_Clinicos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EspecialidadeController : ControllerBase
    {
        private readonly IEspecialidadeRepository _repository;
        private readonly IMapper _mapper;

        public EspecialidadeController(IEspecialidadeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var especialidades = await _repository.GetAsync();

            return especialidades.Any()
                ? Ok(especialidades)
                : BadRequest("Especialidades não encontrada");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var especialidadeId = await _repository.GetByIdAsync(id);

            var especialidadeRetorno = _mapper.Map<EspecialidadeDetalheDto>(especialidadeId);

            if (especialidadeRetorno != null)
            {
                return Ok(especialidadeRetorno);

            }
            return BadRequest("Especialidade não encontrada");
        }

        [HttpPost]
        public async Task<IActionResult> Post(AdicionarEspecialidadeDto especialidade)
        {
            if (especialidade == null) return BadRequest("Dados invalidos");

            var adicionarEspecialidade = _mapper.Map<Especialidade>(especialidade);

            _repository.Add(adicionarEspecialidade);
            return await _repository.SaveChangesAsync()
                ? Ok("Especialidade adicionada com sucesso")
                : BadRequest("Erro ao adicionar especilaidade");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, bool ativo)
        {
            if (id <= 0) return BadRequest("Especialidade invalida");
            var especialidade = await _repository.GetByIdAsync(id);

            if (especialidade == null) return NotFound("Especialidade não encontrada");
            string status = ativo ? "ativa" : "inativa";
            if (especialidade.Ativa == ativo) return Ok($"A especialidade já está {status}");

            especialidade.Ativa = ativo;
            _repository.Update(especialidade);
            return await _repository.SaveChangesAsync()
                ? Ok("Especialidade atualizado com sucesso")
                : BadRequest("Erro ao atualizar a especialidade");
        }
    }
}
