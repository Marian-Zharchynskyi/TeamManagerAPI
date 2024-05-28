using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManagerWeb.Core.Entities;

namespace TeamManagerWeb.Core.Context
{
    public class ProjectContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
        { }
        public DbSet<Platform> Platforms => Set<Platform>();
        public DbSet<AdvertisementForSales> AdvertisementsForSales => Set<AdvertisementForSales>();
        public DbSet<AdvertisementStatus> AdvertisementStatuses => Set<AdvertisementStatus>();
        public DbSet<AdvertisementToFind> AdvertisementsToFind => Set<AdvertisementToFind>();
        public DbSet<Game> Games => Set<Game>();
        public DbSet<GameAccount> GameAccounts => Set<GameAccount>();
        public DbSet<UserGroup> UserGroups => Set<UserGroup>();
        public DbSet<Genre> Genres => Set<Genre>();
        public DbSet<Developer> Developers => Set<Developer>();
        public DbSet<Language> Languages => Set<Language>();

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            DataSeed.Seed(builder);
        }
    }
}
