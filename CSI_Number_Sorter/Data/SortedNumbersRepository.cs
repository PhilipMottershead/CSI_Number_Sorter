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
        private readonly SortedNumbersContext _context;

        public SortedNumbersRepository(SortedNumbersContext context)
        {
            this._context = context;
        }

        public async Task<List<SortedNumbers>> ToListAsync()
        {
            return await _context.SortedNumbers.OrderByDescending(s=>s.TimeTaken).ToListAsync();
        }

        public async Task AddAsync(SortedNumbers sortedNumbers)
        {
            _context.Add(sortedNumbers);
            await _context.SaveChangesAsync();
        }

        public DbSet<SortedNumbers> SortedNumbers()
        {
            return _context.SortedNumbers;
        }

        public async Task<int> CountAsync()
        {
            return await _context.SortedNumbers.CountAsync();
        }

    }
}
