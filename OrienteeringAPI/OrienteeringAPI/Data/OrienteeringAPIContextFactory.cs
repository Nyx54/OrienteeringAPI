using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace OrienteeringAPI.Data
{
    public class OrienteeringAPIContextFactory
    {
        private const string _connectionURLs = "ConnectionsURls";
        private const string _APIConnectionString = "APIConnectionString";

        private IConfiguration _configuration { get; }

        public OrienteeringAPIContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public OrienteeringAPIContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<OrienteeringAPIContext>();
            var urls = _configuration.GetSection(_connectionURLs);
            var connectionString = urls.GetValue<string>(_APIConnectionString);
            optionsBuilder.UseSqlServer(connectionString);
            return new OrienteeringAPIContext(optionsBuilder.Options);
        }
    }
}
