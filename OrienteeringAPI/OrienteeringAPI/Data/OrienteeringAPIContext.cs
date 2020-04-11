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
            modelBuilder.Entity<User>()
               .HasKey(Dto => new { Dto.Id });
        }


        #region DbSet

        public DbSet<User> Users { get; set; }

        #endregion
    }
}
