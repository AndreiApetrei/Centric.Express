using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CentricExpress.DataAccess.Configurations.Tools
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>();

            builder.UseSqlServer(@"Server=.;Database=CentricExpress;Trusted_Connection=True;MultipleActiveResultSets=true");
 
            return new AppDbContext(builder.Options);
        }
    }
}