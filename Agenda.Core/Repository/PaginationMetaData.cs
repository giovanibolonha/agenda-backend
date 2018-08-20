using System;
using System.Collections.Generic;
using System.Text;

namespace Agenda.Core.Repository
{
    public class PaginationMetaData
    {
        public PaginationMetaData(
            int totalCount, 
            int pageSize, 
            int currentPage, 
            int totalPages)
        {
            TotalCount = totalCount;
            PageSize = pageSize;
            CurrentPage = currentPage;
            TotalPages = totalPages;
        }

        public int TotalCount { get; private set; }

        public int PageSize { get; private set; }

        public int CurrentPage { get; private set; }

        public int TotalPages { get; private set; }
    }
}
