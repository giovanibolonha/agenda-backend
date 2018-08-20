using Agenda.Core.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agenda.Core.Repository
{
    public abstract class ParameterBase : IParameter
    {
        const int MaxPageSize = 10;

        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }

            set
            {
                _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
            }
        }
    }
}
