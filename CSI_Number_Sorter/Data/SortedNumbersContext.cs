using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CSI_Number_Sorter.Models;

namespace CSI_Number_Sorter.Data
{
    public class SortedNumbersContext : DbContext
    {
        public SortedNumbersContext (DbContextOptions<SortedNumbersContext> options)
            : base(options)
        {
        }

        public DbSet<CSI_Number_Sorter.Models.SortedNumbers> SortedNumbers { get; set; }
    }
}
