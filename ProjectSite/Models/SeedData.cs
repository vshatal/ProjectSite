using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectSite.Data;
using System;
using System.Linq;

namespace ProjectSite.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new ProjectSiteContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<ProjectSiteContext>>()))
            context.SaveChanges();
    }
}