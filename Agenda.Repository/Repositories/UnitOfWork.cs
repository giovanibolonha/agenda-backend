using Agenda.Core.Repository.Interfaces;
using Agenda.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agenda.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AgendaContext _context;

        public UnitOfWork(AgendaContext context)
        {
            _context = context;
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
