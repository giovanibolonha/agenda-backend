using Agenda.Data.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agenda.Data.Configuration
{
    public class TarefaConfiguration : IEntityTypeConfiguration<TarefaData>
    {
        public void Configure(EntityTypeBuilder<TarefaData> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Titulo)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(i => i.Titulo);

            builder.Property(p => p.Descricao)
                .HasMaxLength(400);

            builder.Property(p => p.DataConclusao);

            builder.HasIndex(i => i.DataConclusao);

            builder.HasIndex(i => i.DeletedDate);
        }
    }
}
