using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectSite.Models;

namespace ProjectSite.Data
{
    public class ProjectSiteContext : DbContext
    {
        public ProjectSiteContext (DbContextOptions<ProjectSiteContext> options)
            : base(options)
        {
        }

        public DbSet<ProjectSite.Models.Restaurant> Restaurant { get; set; } = default!;
        public DbSet<ProjectSite.Models.Review> Review { get; set; } = default!;
    }
}
