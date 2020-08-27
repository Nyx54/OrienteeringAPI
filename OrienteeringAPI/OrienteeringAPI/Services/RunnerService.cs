using OrienteeringAPI.Repositories;
using OrienteeringAPI.Services.Base;
using OrienteeringModels.Dtos;

namespace OrienteeringAPI.Services
{
    public class RunnerService : AbstractBaseService<RunnerRepository, OrienteeringRunner>
    {

        public RunnerService(RunnerRepository repository) : base(repository)
        {
        }
    }
}
