using System;
using System.Collections.Generic;
using System.Text;

namespace Agenda.Core.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        int Complete();

        void Dispose();
    }
}
