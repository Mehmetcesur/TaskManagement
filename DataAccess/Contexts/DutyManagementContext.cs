using Core.Entities.Concretes;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;


namespace DataAccess.Contexts;

public class DutyManagementContext : DbContext
{
    protected IConfiguration Configuration { get; set; }

    public DbSet<Duty> Duties { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }



    public DutyManagementContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
    {
        // Configuration = configuration;
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     if (!optionsBuilder.IsConfigured)
    //     {
    //         throw new Exception("DbContext options must be configured before usage");
    //     }
    // }

}
