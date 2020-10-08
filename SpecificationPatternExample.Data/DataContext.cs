using Microsoft.EntityFrameworkCore;
using SpecificationPatternExample.Data.Models;

namespace SpecificationPatternExample.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> dbContextOptions) : base(dbContextOptions)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<UserModel> UserModels { get; set; }
    }
}