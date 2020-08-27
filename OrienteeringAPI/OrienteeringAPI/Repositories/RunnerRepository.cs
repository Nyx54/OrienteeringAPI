using OrienteeringAPI.Data;
using OrienteeringAPI.Repositories.Base;
using OrienteeringModels.Dtos;

namespace OrienteeringAPI.Repositories
{
    public class RunnerRepository : AbstractBaseRepository<OrienteeringRunner, OrienteeringAPIContextFactory>
    {

        public RunnerRepository(OrienteeringAPIContextFactory factory) : base(factory)
        {

        }
    }
}
