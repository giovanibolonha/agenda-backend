using Agenda.Data.Configuration;
using Agenda.Data.DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agenda.Data
{
    public class AgendaContext : DbContext
    {
        public virtual DbSet<TarefaData> Tarefas { get; set; }

        public AgendaContext(DbContextOptions<AgendaContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TarefaConfiguration());
        }
    }
}
