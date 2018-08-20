using System;
using System.Collections.Generic;
using System.Text;

namespace Agenda.Core.Repository.Interfaces
{
    public interface IRepository<T>
    {
        T Get(Guid id);

        IEnumerable<T> GetAll();

        void Add(T model);

        void Update(T model);

        void Delete(Guid id);
    }
}
