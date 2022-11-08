using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GitInsight.Models;

public partial class GitInsightContext : DbContext
{
  public GitInsightContext()
  {
  }

  public GitInsightContext(DbContextOptions<GitInsightContext> options)
      : base(options)
  {
  }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    var configuration = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
    var connectionString = configuration.GetConnectionString("GitInsight");

    optionsBuilder.UseNpgsql(connectionString);
  }


  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    OnModelCreatingPartial(modelBuilder);
  }

  partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
