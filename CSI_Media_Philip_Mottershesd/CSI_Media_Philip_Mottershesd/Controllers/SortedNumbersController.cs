using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CSI_Media_Philip_Mottershesd.Data;
using CSI_Media_Philip_Mottershesd.Models;
using Microsoft.Extensions.Localization;

namespace CSI_Media_Philip_Mottershesd.Controllers
{
    public class SortedNumbersController : Controller
    {
        private readonly SortedNumbersContext _context;

        private readonly IStringLocalizer<SortedNumbersController> _localizer;
        public SortedNumbersController(SortedNumbersContext context, IStringLocalizer<SortedNumbersController> localizer)
        {
            _context = context;
            _localizer = localizer;
        }

        // GET: SortedNumbers
        public async Task<IActionResult> Index()
        {
            return View(await _context.SortedNumbers.ToListAsync());
        }

        // GET: SortedNumbers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sortedNumbers = await _context.SortedNumbers
                .FirstOrDefaultAsync(m => m.SortedNumbersId == id);
            if (sortedNumbers == null)
            {
                return NotFound();
            }

            return View(sortedNumbers);
        }

        // GET: SortedNumbers/Create
        public IActionResult Create()
        {
            List<SelectListItem> list = new List<SelectListItem> {
                new SelectListItem {Text=_localizer["Ascending"],Value="0",Selected=true},
                new SelectListItem {Text=_localizer["Descending"],Value="1" },
            };
            ViewBag.List = list;
            return View();
        }

        // POST: SortedNumbers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SortedNumbersId,Numbers,SortOrder")] SortedNumbers sortedNumbers)
        {
            if (ModelState.IsValid)
            {
                sortedNumbers = sortNumbers(sortedNumbers);
                _context.Add(sortedNumbers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                
            }
            return View(sortedNumbers);
        }

        private SortedNumbers sortNumbers(SortedNumbers sortedNumbers) 
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            String numbers = sortedNumbers.Numbers;
            int direction = sortedNumbers.SortOrder;

            var nums = numbers.Split(",").ToList();
            var resultsList = new List<int>();
            nums.ForEach(n => resultsList.Add(int.Parse(n)));
            resultsList.Sort();
            if (direction == 1)
            {
                resultsList.Reverse();
            }
            watch.Stop();
            sortedNumbers.Numbers = string.Join(",",resultsList);
            sortedNumbers.TimeTaken = watch.Elapsed;
            return sortedNumbers;
        }

        [AcceptVerbs("GET","POST")]
        public IActionResult CheckNumbersInput(string numbers)
        {
            try
            {
                numbers.Split(',').ToList().ForEach(n => int.Parse(n));
            }
            catch (Exception e)
            {
                if (e.GetType().FullName == "FormatException")
                {
                    return Json("format");
                }
                else
                {
                    return Json("Too long");
                }
            }
            return Json(true);
        }


        // GET: SortedNumbers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sortedNumbers = await _context.SortedNumbers.FindAsync(id);
            if (sortedNumbers == null)
            {
                return NotFound();
            }
            return View(sortedNumbers);
        }

        // POST: SortedNumbers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SortedNumbersId,Numbers,SortOrder,TimeTaken")] SortedNumbers sortedNumbers)
        {
            if (id != sortedNumbers.SortedNumbersId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sortedNumbers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SortedNumbersExists(sortedNumbers.SortedNumbersId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(sortedNumbers);
        }

        // GET: SortedNumbers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sortedNumbers = await _context.SortedNumbers
                .FirstOrDefaultAsync(m => m.SortedNumbersId == id);
            if (sortedNumbers == null)
            {
                return NotFound();
            }

            return View(sortedNumbers);
        }

        // POST: SortedNumbers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sortedNumbers = await _context.SortedNumbers.FindAsync(id);
            _context.SortedNumbers.Remove(sortedNumbers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SortedNumbersExists(int id)
        {
            return _context.SortedNumbers.Any(e => e.SortedNumbersId == id);
        }
    }
}
