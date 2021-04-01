using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
  public class WMPolicyContext : DbContext
  {
    public WMPolicyContext(DbContextOptions<WMPolicyContext> options) : base(options)
    {     
    }

    public DbSet<Coverage> Coverages { get; set; }
    public DbSet<CoverageAreaLimit> CoverageAreaLimits { get; set; }
    public DbSet<Insured> Insureds { get; set; }
    public DbSet<Policy> Policies { get; set; }
    // public DbSet<PolicyCoverage> PolicyCoverages { get; set; }
    public DbSet<Property> Properties { get; set; }
    public DbSet<States> StatesDb { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      var cover2 = new Coverage { Id = 2, Description = "Coverage2", Cost = 20 };
      modelBuilder.Entity<Coverage>().HasData(
        new Coverage { Id = 1, Description = "Coverage1", Cost = 10},
        cover2,
        new Coverage { Id = 3, Description = "Coverage3", Cost = 30 },
        new Coverage { Id = 4, Description = "Coverage4", Cost = 40 },
        new Coverage { Id = 5, Description = "Coverage5", Cost = 50 }
        );

      modelBuilder.Entity<States>().HasData(
        new States { Id = 1, State = "AZ", Description = "Arizona"},
        new States { Id = 2, State = "CA", Description = "California" },
        new States { Id = 3, State = "NY", Description = "New York" }
        );

    }
  }
}
