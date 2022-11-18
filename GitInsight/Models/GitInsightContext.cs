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


  public virtual DbSet<Commit> Commits => Set<Commit>();
  public virtual DbSet<User> Users => Set<User>();
  public virtual DbSet<Repository> Repositories => Set<Repository>();
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    OnModelCreatingPartial(modelBuilder);

    var commitEntity = modelBuilder.Entity<Commit>();
    commitEntity
      .HasIndex(c => c.Id)
      .IsUnique();
    commitEntity
      .Property(c => c.Id)
      .IsRequired();

    commitEntity
      .HasIndex(c => c.User_Id)
      .IsUnique();
    commitEntity
      .Property(c => c.User_Id)
      .IsRequired();

    commitEntity
      .HasIndex(c => c.Repo_Id)
      .IsUnique();
    commitEntity
      .Property(c => c.Repo_Id)
      .IsRequired();

    commitEntity
      .Property(c => c.date)
      .IsRequired();

    var repositoryEntity = modelBuilder.Entity<Repository>();
    repositoryEntity
      .HasIndex(r => r.Id)
      .IsUnique();

    repositoryEntity
      .Property(r => r.Id)
      .IsRequired();

    repositoryEntity
      .HasIndex(r => r.url)
      .IsUnique();

    repositoryEntity
      .Property(r => r.url)
      .IsRequired();

    repositoryEntity
      .Property(r => r.lastCommitId)
      .IsRequired();

    repositoryEntity
      .HasIndex(r => r.lastCommitId)
      .IsUnique();

    var userEntity = modelBuilder.Entity<User>();
    userEntity
      .HasIndex(u => u.Id)
      .IsUnique();

    userEntity
      .Property(u => u.Id)
      .IsRequired();

    userEntity
    .Property(u => u.Name)
    .IsRequired();
  }

  partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}



// q: how do we structure a database that keeps track of results of a commit history analysis on a repository?
// a: we need a table for results, a table for users, and a table for repositories

// q: what are the columns in the results table?
// a: id, user_id, repo_id, date, commits_per_day

// q: what are the columns in the users table?
// a: id, name

// q: what are the columns in the repositories table?
// a: id, url, last_commit_id

// q: what are the relationships between the tables?
// a: results.user_id -> users.id
//    results.repo_id -> repositories.id

