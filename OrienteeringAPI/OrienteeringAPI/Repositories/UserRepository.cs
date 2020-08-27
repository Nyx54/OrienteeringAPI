using Microsoft.EntityFrameworkCore;
using OrienteeringAPI.Data;
using OrienteeringAPI.Repositories.Base;
using OrienteeringModels.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrienteeringAPI.Repositories
{
    public class UserRepository : IUserRepository
    {

        protected OrienteeringAPIContext context;
        protected readonly OrienteeringAPIContextFactory _factory;

        public UserRepository(OrienteeringAPIContextFactory factory)
        {

            _factory = factory;
        }

        public async Task<List<OrienteeringUser>> GetAll()
        {
            this.context = _factory.CreateDbContext();
            return await context.Set<OrienteeringUser>().ToListAsync();
        }
    }
}
