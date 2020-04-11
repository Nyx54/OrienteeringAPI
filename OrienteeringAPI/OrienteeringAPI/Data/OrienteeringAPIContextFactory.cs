using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace OrienteeringAPI.Data
{
    public class OrienteeringAPIContextFactory
    {
        private readonly OrienteeringAPIContext _context;

        private IConfiguration _configuration { get; }

        public OrienteeringAPIContextFactory(IConfiguration configuration)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OrienteeringAPIContext>();
            optionsBuilder.UseSqlServer("url");
            _context = new OrienteeringAPIContext(optionsBuilder.Options);
            _configuration = configuration;
        }

        public OrienteeringAPIContext CreateDbContext(string[] args)
        {
            return _context;
        }
    }
}
