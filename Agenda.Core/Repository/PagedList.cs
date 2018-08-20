using Agenda.Core.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agenda.Core.Repository
{
    public class PagedList<T> : List<T>, IPagedList<T>
    {
        public int CurrentPage { get; private set; }

        public int TotalPages { get; private set; }

        public int PageSize { get; private set; }

        public int TotalCount { get; private set; }

        public bool HasPrevious
        {
            get
            {
                return (CurrentPage > 1);
            }
        }

        public bool HasNext
        {
            get
            {
                return (CurrentPage < TotalPages);
            }
        }

        public PagedList(IEnumerable<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }

        public PaginationMetaData CreateMetaData()
        {
            return new PaginationMetaData(TotalCount, PageSize, CurrentPage, TotalPages);
        }
    }
}
