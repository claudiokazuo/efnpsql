﻿using Microsoft.EntityFrameworkCore;
using Shared.Entities;
using Shared.Pagination.Contracts;
using Shared.Pagination.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Pagination.PagedLists
{
    public class GenericPagedList<T> : IPagedList<T> where T : Entity
    {
        public MetaData Pagination { get; set; }
        public IEnumerable<T> Items { get; }

        private GenericPagedList(
            IEnumerable<T> items,
            int totalCount,
            int pageNumber,
            int pageSize)
        {
            Pagination = new MetaData(pageNumber, pageSize, totalCount);
            Items = items;
        }

        public static async Task<GenericPagedList<T>> ToPagedList(
           IQueryable<T> source,
           int pageNumber,
           int pageSize)
        {
            var count = await source.CountAsync();

            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            var result = await items.ToListAsync();

            return new GenericPagedList<T>(result, count, pageNumber, pageSize);
        }
    }
}
