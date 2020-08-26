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
    }
}
