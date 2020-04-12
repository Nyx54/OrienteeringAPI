using OrienteeringModels.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrienteeringAPI.Repositories.Base
{
    public interface ILogRepository
    {
        Task<LogAPI> Add(LogAPI entity);
        Task<LogAPI> Update(LogAPI entity);
    }
}
