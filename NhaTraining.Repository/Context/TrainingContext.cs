using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Cosmos.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Microsoft.Extensions.Configuration;
using NhaTraining.Repository.Data;


namespace NhaTraining.Repository.Context
{
    public class TrainingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        //public TrainingContext(DbContextOptions options) : base(options)
        //{

        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().Property(p => p.Id).HasValueGenerator<GuidValueGenerator>();
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.HasDefaultContainer("Blogs");
            //modelBuilder.Entity<Blog>().ToContainer("Blogs");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseCosmos("https://localhost:8081",
           "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==", "TrainingDb");
        }
    }
}
