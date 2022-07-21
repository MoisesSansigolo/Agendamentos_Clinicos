using Agendamentos_Clinicos.Models.Dtos;
using Agendamentos_Clinicos.Models.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agendamentos_Clinicos.Helpers
{
    public class AgendamentoProfile : Profile
    {
        public AgendamentoProfile()
        {
            CreateMap<Paciente, PacienteDetalheDto>();
                //.ForMember(dest => dest.Email, opt => opt.Ignore()); //USADO PARA ESCONDER DETALHES DO CAMPO
            CreateMap<Consulta, ConsultaDto>()
                .ForMember(dest => dest.Especialidade, opt => opt.MapFrom(src => src.Especialidade.Nome))
                .ForMember(dest => dest.Profissional, opt => opt.MapFrom(src => src.Profissional.Nome));

            CreateMap<AdicionarPacienteDto, Paciente>();
            CreateMap<AtualizandoPacienteDto, Paciente>()
                .ForAllMembers(opts => opts.Condition((src, Dest, srcMember) => srcMember != null));

            CreateMap<Profissional, ProfissionalDetalhesDto>()
                .ForMember(dest => dest.TotalConsultas, opt => opt.MapFrom(src => src.Consultas.Count()))
                .ForMember(dest => dest.Especialidades, opt => opt.MapFrom(src => src.Especialidades.Select(x => x.Nome).ToArray()));

            CreateMap<AdicionarProfissionalDto, Profissional>();
            CreateMap<AtualizarProfissionalDto, Profissional>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
