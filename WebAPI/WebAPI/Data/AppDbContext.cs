using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<Incidents> Incident { get; set; }

        public DbSet<Accounts> Account { get; set; }
        public DbSet<Contacts> Contact { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contacts>()
            .HasOne(p => p.Account)
            .WithMany(t => t.Contact)
            .HasForeignKey(p => p.Username);
            modelBuilder.Entity<Accounts>()
           .HasOne(p => p.Incident)
           .WithMany(t => t.Account)
           .HasForeignKey(p => p.Incidents);
        }
    }
}
