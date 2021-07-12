using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CSI_Number_Sorter.Models
{
    public class SortedNumbers
    {
        public int SortedNumbersId { get; set; }
        [Remote(action: "CheckNumbersInput", controller: "SortedNumbers")]
        [Required]
        [Display(Name = "Numbers", ResourceType = typeof(Resources.Models.SortedNumbers))]
        public string Numbers { get; set; }
        [Required]
        [Display(Name = "SortOrder", ResourceType = typeof(Resources.Models.SortedNumbers))]
        public int SortOrder { get; set; }

        [Display(Name = "TimeTaken", ResourceType = typeof(Resources.Models.SortedNumbers))]
        public TimeSpan TimeTaken { get; set; }

        public void Sort()
        {
            var watch = new Stopwatch();
            watch.Start();
            var nums = Numbers.Split(",").ToList();
            Numbers = string.Join(",", SortOrder == 0 ? nums.OrderBy(n => n) : nums.OrderByDescending(n => n));         
            watch.Stop();
            TimeTaken = watch.Elapsed;
        }

    }
}
