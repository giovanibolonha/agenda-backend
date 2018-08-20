using System;
using System.Collections.Generic;
using System.Text;

namespace Agenda.Core.Repository.Interfaces
{
    public interface IParameter
    {
        int PageNumber { get; set; }

        int PageSize { get; set; }
    }
}
