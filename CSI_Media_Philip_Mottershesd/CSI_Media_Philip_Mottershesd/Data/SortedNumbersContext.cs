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

        public DbSet<SortedNumbers> SortedNumbers { get; set; }
    }
}
