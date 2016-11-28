using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonFinancialReportsAPI
{
    public class BangazonContext : DbContext
    {
        public BangazonContext(DbContextOptions<BangazonContext> options)
            : base(options)
        { }

        //This is where we are building the database, using the DbContext method of DbSet. DbSet exists in memory, not in database yet
        public DbSet<Revenue> Revenue { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Revenue>();

        }
    }

}