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
    [Route("api[controller]")]
    public class AgendarConsultaController : ControllerBase
    {
        private readonly IConsultaRepository _repository;
        private readonly IMapper _mapper;

        public AgendarConsultaController(IConsultaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]ConsultaParams parametro)
        {
            var consultas = await _repository.GetConsultas(parametro);

            var consultaRetorno = _mapper.Map<IEnumerable<ConsultaDetalhesDto>>(consultas);

            return consultaRetorno.Any()
                ? Ok(consultaRetorno)
                : NotFound();            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0) return BadRequest("Consulta inválida");

            var consulta = await _repository.GetConsultasById(id);

            var consultaRetorno = _mapper.Map<ConsultaDetalhesDto>(consulta);

            if(consultaRetorno != null)
            {
                return Ok(consultaRetorno);
            }
            else
            {
                return NotFound("Consulta não encontrada");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Post(AdicionarConsultaDto consulta)
         {
            if (consulta == null)
            {
                return BadRequest("Dados da consulta inválida");
            }

            var adicionarConsulta = _mapper.Map<Consulta>(consulta);
            _repository.Add(adicionarConsulta);
            return await _repository.SaveChangesAsync()
                ? Ok("Consulta Agendada")
                : BadRequest("Erro ao tentar agendar a consulta");
         }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, AtualizaConsultaDto consulta)
        {
            if (consulta == null)
            {
                return BadRequest("Dados da consulta inválida");
            }
            var consultaBanco = await _repository.GetConsultasById(id);

            if (consultaBanco == null)
            {
                return BadRequest("Consulta não existe");
            }
            if(consulta.DataHorario == new DateTime())
            {
                consulta.DataHorario = consultaBanco.DataHorario;
            }

            var AtualiazarConsulta = _mapper.Map(consulta, consultaBanco);
            _repository.Update(AtualiazarConsulta);
            return await _repository.SaveChangesAsync()
                ? Ok("Consulta atualizada com sucesso")
                : BadRequest("Erro ao tentar atualizar a consulta");
        }
    }
}
