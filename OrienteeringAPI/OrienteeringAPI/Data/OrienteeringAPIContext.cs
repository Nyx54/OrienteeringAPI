using Microsoft.EntityFrameworkCore;
using OrienteeringModels.Dtos;

namespace OrienteeringAPI.Data
{
    public class OrienteeringAPIContext : DbContext
    {

        public OrienteeringAPIContext(DbContextOptions<OrienteeringAPIContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Fluent API
        /// Définition des clés primaires des models
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LogAPI>()
               .HasKey(Dto => new { Dto.Id });

            modelBuilder.Entity<OrienteeringLeague>()
               .HasKey(Dto => new { Dto.Id });
            modelBuilder.Entity<OrienteeringTeam>()
               .HasKey(Dto => new { Dto.Id });
            modelBuilder.Entity<OrienteeringUser>()
               .HasKey(Dto => new { Dto.Id });


        }


        #region DbSet

        public DbSet<LogAPI> LogAPI { get; set; }

        public DbSet<OrienteeringLeague> OrienteeringLeague { get; set; }
        public DbSet<OrienteeringTeam> OrienteeringTeam { get; set; }
        public DbSet<OrienteeringUser> OrienteeringUser { get; set; }

        #endregion
    }
}
