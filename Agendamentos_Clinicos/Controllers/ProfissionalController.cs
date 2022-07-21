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
    public class ProfissionalController : ControllerBase
    {
        private readonly IProfissionalRepository _repository;
        private readonly IMapper _mapper;

        public ProfissionalController(IProfissionalRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var profissional = await _repository.Get();

            return profissional.Any()
                ? Ok(profissional)
                : NotFound("Profisional não encontrado");           

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0) return BadRequest("Profissional invalido");

            var profissional = await _repository.GetByIdAsync(id);

            var RetornoProfissional = _mapper.Map<ProfissionalDetalhesDto>(profissional);

            if(RetornoProfissional == null)
            {
                return NotFound("Profissional não encontrado");
            }
            return Ok(RetornoProfissional);
        }  

        [HttpPost]

        public async Task<IActionResult> Post(AdicionarProfissionalDto profissional)
        {
            if (string.IsNullOrEmpty(profissional.Nome))
            {
                return BadRequest("O nome é obrigatório");
            }
            var adicionarProfissional = _mapper.Map<Profissional>(profissional);

            _repository.Add(adicionarProfissional);
            return await _repository.SaveChangesAsync()
                ? Ok("Profissional adicionado com sucesso")
                : BadRequest("Erro ao tentar adicionar o profissional");            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, AtualizarProfissionalDto profissional)
        {
            if (id <= 0) return BadRequest("Profissional inválido");

            var profissionalExiste = await _repository.GetByIdAsync(id);

            if (profissionalExiste == null)
            {
                return NotFound("Profissional não encontrado");
            }
            var atualizarProfissional = _mapper.Map(profissional, profissionalExiste);
            _repository.Update(atualizarProfissional);
            return await _repository.SaveChangesAsync()
                ? Ok("Profissional atualizado")
                : BadRequest("Erro ao tentar atualizar o profissional");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Profissional não encontrado");
            }
            var excluirProfissional = await _repository.GetByIdAsync(id);

            if (excluirProfissional == null)
            {
                return NotFound("Profissional não exite");
            }
            _repository.Delete(excluirProfissional);
            return await _repository.SaveChangesAsync()
                ? Ok("Profissional excluido com sucesso")
                : BadRequest("Erro ao tentar excluir o funcionario");
        }

    }
}
