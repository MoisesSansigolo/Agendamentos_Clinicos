using Agendamentos_Clinicos.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agendamentos_Clinicos.Map
{
    public class EspecialidadeMap : BaseMap<Especialidade>
    {
        public EspecialidadeMap() : base("tb_especialidade")
        {
        }

        public override void Configure(EntityTypeBuilder<Especialidade> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Nome).HasColumnName("name").IsRequired();
            builder.Property(x => x.Ativa).HasColumnName("ativa");
        }
    }
}
