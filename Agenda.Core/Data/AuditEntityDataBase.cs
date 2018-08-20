using Agenda.Core.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agenda.Core.Data
{
    public class AuditEntityDataBase<TPrimaryKey> 
        : EntityDataBase<TPrimaryKey>, IAudityEntityData<TPrimaryKey>
    {
        protected AuditEntityDataBase()
        {
            CreatedDate = DateTime.Now;
        }

        public DateTime CreatedDate { get; private set; }

        public DateTime? UpdatedDate { get; private set; }

        public DateTime? DeletedDate { get; private set; }

        public void OnAuditInsert(DateTime when)
        {
            CreatedDate = when;
        }

        public void OnAuditUpdate(DateTime when)
        { 
            UpdatedDate = when;
        }

        public void OnAuditDelete(DateTime when)
        {
            DeletedDate = when;
        }
    }
}
