using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Domain.Models.Common
{
    public class PagedResult<TEntity>
    {
        public PagedResult(int currentPage, int totalPages, int totalItems, List<TEntity> items)
        {
            CurrentPage = currentPage;
            TotalPages = totalPages;
            Items = items;
            TotalItems = totalItems;
        }

        public virtual int CurrentPage { get; set; }
        public virtual int TotalPages { get; set; }
        public virtual int TotalItems { get; set; }
        public virtual List<TEntity> Items { get; set; }
    }
}
