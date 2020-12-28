using Microsoft.EntityFrameworkCore;
using Api.Domain.Entities;
using Api.Data.Mapping;
using System;

namespace Api.Data.Context
{
  public class MyContext : DbContext
  {
    DbSet<UserEntity> Users { get; set; }

    public MyContext(DbContextOptions<MyContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      modelBuilder.Entity<UserEntity>(new UserMap().Configure);

      modelBuilder.Entity<UserEntity>().HasData(
        new UserEntity
        {
          Id = Guid.NewGuid(),
          Name = "Administrator",
          Email = "ajvm10@gmail.com",
          CreateAt = DateTime.Now,
          UpdateAt = DateTime.Now
        }
      );
    }
  }
}