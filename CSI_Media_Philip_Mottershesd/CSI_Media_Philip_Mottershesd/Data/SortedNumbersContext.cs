using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CSI_Media_Philip_Mottershesd.Models;

namespace CSI_Media_Philip_Mottershesd.Data
{
    public class SortedNumbersContext : DbContext
    {
        public SortedNumbersContext (DbContextOptions<SortedNumbersContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<SortedNumbers>()
            // .Property(e => e.Numbers)
            // .HasConversion(
            //     v => string.Join(',', v),
            //     v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
        }



        public DbSet<CSI_Media_Philip_Mottershesd.Models.SortedNumbers> SortedNumbers { get; set; }
    }
}
