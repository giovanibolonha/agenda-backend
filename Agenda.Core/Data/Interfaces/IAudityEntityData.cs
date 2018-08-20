using System;
using System.Collections.Generic;
using System.Text;

namespace Agenda.Core.Data.Interfaces
{
    public interface IAudityEntityData<TPrimaryKey> : IEntityData<TPrimaryKey>
    {
        DateTime CreatedDate { get; }

        DateTime? UpdatedDate { get; }

        DateTime? DeletedDate { get; }

        void OnAuditInsert(DateTime when);

        void OnAuditUpdate(DateTime when);

        void OnAuditDelete(DateTime when);
    }
}
