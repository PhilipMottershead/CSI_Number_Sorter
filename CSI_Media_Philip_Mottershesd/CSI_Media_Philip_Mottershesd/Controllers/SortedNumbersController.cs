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
        private readonly SortedNumbersRepository _context;

        private readonly IStringLocalizer<SortedNumbersController> _localizer;
        public SortedNumbersController(SortedNumbersRepository context, IStringLocalizer<SortedNumbersController> localizer)
        {
            _context = context;
            _localizer = localizer;
        }

        // GET: SortedNumbers
        public async Task<IActionResult> Index()
        {
            return View(await _context.ToListAsync());
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
                sortedNumbers = SortNumbers(sortedNumbers);
                await _context.AddAsync(sortedNumbers);
                return RedirectToAction(nameof(Index));
                
            }
            return View(sortedNumbers);
        }

        private SortedNumbers SortNumbers(SortedNumbers sortedNumbers) 
        {
            var watch = new System.Diagnostics.Stopwatch();
            var numbers = sortedNumbers.Numbers;
            var direction = sortedNumbers.SortOrder;

            watch.Start();

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
    }
}
