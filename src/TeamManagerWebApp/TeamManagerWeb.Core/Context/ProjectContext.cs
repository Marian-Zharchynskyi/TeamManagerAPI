using Microsoft.EntityFrameworkCore;
using TeamManagerWeb.Core.Entities;

namespace TeamManagerWeb.Core.Context
{
    public class ProjectContext:DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
        { }
        
        public DbSet<Language> Languages => Set<Language>();

        

        /* protected override void OnModelCreating(ModelBuilder builder)
         {

             base.OnModelCreating(builder);

             DataSeed.Seed(builder);
         }*/
    }
}
