using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SpecificationPatternExample.ConfigSection;
using SpecificationPatternExample.Data;

namespace SpecificationPatternExample
{
    public class DataContextDesignTime : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            string connectionString = AppConfigs.GetDbConnectionString();

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<DataContext>();
            dbContextOptionsBuilder.UseSqlServer(connectionString);

            DbContextOptions<DataContext> dbContextOptions = dbContextOptionsBuilder.Options;
            return new DataContext(dbContextOptions);
        }
    }
}