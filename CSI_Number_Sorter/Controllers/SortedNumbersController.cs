using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CSI_Number_Sorter.Data;
using CSI_Number_Sorter.Models;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;

namespace CSI_Number_Sorter.Controllers
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

        public async Task<ActionResult> Export()
        {
            var list = await _context.ToListAsync();
            string strserialize = JsonConvert.SerializeObject(list, Formatting.Indented);
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(strserialize);
            var output = new FileContentResult(bytes, System.Net.Mime.MediaTypeNames.Application.Json)
            {
                FileDownloadName = "download.json"
            };
            return output;
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
                sortedNumbers.Sort();
                await _context.AddAsync(sortedNumbers);
                return RedirectToAction(nameof(Index));
                
            }
            return View(sortedNumbers);
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
                return Json(e.Message);
            }
            return Json(true);
        }
    }
}
