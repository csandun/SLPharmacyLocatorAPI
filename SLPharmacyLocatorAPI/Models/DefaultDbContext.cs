using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SLPharmacyLocatorAPI.Models
{
    public class DefaultDbContext : DbContext
    {
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options)
               : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pharmacy>(entity =>
            {
                entity.HasKey(t => t.Id);
            });
        }

        public DbSet<Pharmacy> Pharmacy { get; set; }

    }
}
