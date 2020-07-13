using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace EindoefeningMVC1.Models
{
    public class BestemmingModel
    {
        [Required(ErrorMessage = "vul een bestemming in")]
        public String Bestemming { get; set; }
        public int ID { get; set; }
    }
}
