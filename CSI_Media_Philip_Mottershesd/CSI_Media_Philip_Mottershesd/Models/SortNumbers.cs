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
        public string Numbers { get; set; }
        [Required]
        public int SortOrder { get; set; }
        public TimeSpan TimeTaken { get; set; }

    }
}
