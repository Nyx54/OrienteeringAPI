using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace OrienteeringAPI.Data
{
    public class OrienteeringAPIContextFactory
    {
        private readonly OrienteeringAPIContext _context;
        private const string _connectionURLs = "ConnectionsURls";
        private const string _APIConnectionString = "APIConnectionString";

        private IConfiguration _configuration { get; }

        public OrienteeringAPIContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;

            var optionsBuilder = new DbContextOptionsBuilder<OrienteeringAPIContext>();
            var urls = _configuration.GetSection(_connectionURLs);
            var connectionString = urls.GetValue<string>(_APIConnectionString);
            optionsBuilder.UseSqlServer(connectionString);

            _context = new OrienteeringAPIContext(optionsBuilder.Options);
        }

        public OrienteeringAPIContext CreateDbContext()
        {
            return _context;
        }
    }
}
