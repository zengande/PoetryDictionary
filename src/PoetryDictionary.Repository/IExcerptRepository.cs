using PoetryDictionary.Database.Models;
using SmartSql.DyRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PoetryDictionary.Repository
{
    public interface IExcerptRepository : IRepository<Excerpt, long>, IRepositoryAsync<Excerpt, long>
    {
    }
}
