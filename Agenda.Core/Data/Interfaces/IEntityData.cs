using System;
using System.Collections.Generic;
using System.Text;

namespace Agenda.Core.Data.Interfaces
{
    public interface IEntityData<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
        bool IsNew { get; }
    }
}
