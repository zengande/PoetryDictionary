using SmartSql.IdGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoetryDictionary.API.Infrastructures
{
    public class IdGeneratorFactory
    {
        private IIdGeneratorBuilder _builder;
        public IdGeneratorFactory(IIdGeneratorBuilder builder)
        {
            _builder = builder;
        }

        public IIdGenerator CreateSnowflakeIdGenerator()
        {
            var parameters = new Dictionary<string, object>
            {
                { "WorkerIdBits", 10 },
                { "WorkerId", 1 },
                { "Sequence", 1 }
            };
            return _builder.Build(nameof(SnowflakeId), parameters);
        }
    }
}
