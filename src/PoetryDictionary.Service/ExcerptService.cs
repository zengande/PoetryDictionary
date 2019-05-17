using PoetryDictionary.Database.Models;
using PoetryDictionary.Repository;
using SmartSql;
using SmartSql.Bulk;
using SmartSql.Bulk.MySql;
using SmartSql.DbSession;
using SmartSql.IdGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoetryDictionary.Service
{
    public class ExcerptService
    {
        private readonly IExcerptRepository _repository;
        public ExcerptService(IExcerptRepository repository)
        {
            _repository = repository;
        }

        public IList<Excerpt> Query(object reqParams = null)
        {
            return _repository.Query(reqParams);
        }

        public async Task<IList<Excerpt>> QueryAsync(object reqParams = null)
        {
            return await _repository.QueryAsync(reqParams);
        }

        public long Insert(Excerpt entity)
        {
            return _repository.SqlMapper.ExecuteScalar<long>(new RequestContext
            {
                Scope = nameof(Excerpt),
                SqlId = "Insert",
                Request = entity,
            });
        }

        public void BulkInsert(IEnumerable<Excerpt> excerpts)
        {
            using (var session = _repository.SqlMapper.SessionStore.Open())
            {
                var table = excerpts.ToDataTable();
                table.TableName = "t_excerpt";
                var bulkInsert = new BulkInsert(session)
                {
                    Table = table,
                    SecureFilePriv = @"C:\ProgramData\MySQL\MySQL Server 8.0\Uploads"
                };
                bulkInsert.Insert();
            }
        }
    }
}
