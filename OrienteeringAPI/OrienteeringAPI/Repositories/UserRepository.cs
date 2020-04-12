using OrienteeringAPI.Data;
using OrienteeringAPI.Repositories.Base;
using OrienteeringModels.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrienteeringAPI.Repositories
{
    public class UserRepository : AbstractBaseRepository<OrienteeringUser, OrienteeringAPIContextFactory>
    {

        public UserRepository(OrienteeringAPIContextFactory factory) : base(factory)
        {

        }
    }
}
