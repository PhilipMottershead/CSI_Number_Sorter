using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSI_Media_Philip_Mottershesd.Models
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

    }
}
