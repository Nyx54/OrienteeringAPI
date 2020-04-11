using OrienteeringAPI.Data;
using OrienteeringAPI.Repositories.Base;
using OrienteeringModels.Dtos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace OrienteeringAPI.Repositories
{
    public class LogRepository : AbstractBaseRepository<LogAPI, OrienteeringAPIContextFactory>, ILogRepository
    {
        public LogRepository(OrienteeringAPIContextFactory factory) : base(factory)
        {
        }

        public async Task<LogAPI> AddResponse(LogAPI entity)
        {
            this.context = _factory.CreateDbContext(new string[] { });
            var dbSet = context.Set<LogAPI>();
            var modelType = dbSet.GetType();
            var modelName = modelType.GenericTypeArguments[0].Name;
            var paramName = modelName.Trim('_');

            DataTable table = entity.ConvertToDataTable();
            SqlParameter parameter = new SqlParameter($"@{paramName}", table);
            parameter.SqlDbType = SqlDbType.Structured;
            parameter.TypeName = $"{_CustomDataType}_{modelName}";

            // var res = await dbSet.FromSqlRaw($"{modelName}_{_PutEndPoint} @{paramName} ", parameter).ToListAsync();
            // return (res == null || res.Count == 0) ? null : res[0];
            return null;
        }
    }
}
