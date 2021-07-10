using CSI_Number_Sorter.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSI_Number_Sorter.Data
{
    public class SortedNumbersRepository
    {
        private readonly SortedNumbersContext context;

        public SortedNumbersRepository(SortedNumbersContext context)
        {
            this.context = context;
        }

        public async Task<List<SortedNumbers>> ToListAsync()
        {
            return await context.SortedNumbers.ToListAsync();
        }

        public async Task AddAsync(SortedNumbers sortedNumbers)
        {
            context.Add(sortedNumbers);
            await context.SaveChangesAsync();
        }
    }
}
