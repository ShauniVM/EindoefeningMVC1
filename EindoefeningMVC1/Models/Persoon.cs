using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EindoefeningMVC1.Models
{
    public class Persoon
    {
        [Required(ErrorMessage = "Naam")]
        public string Naam { get; set; }
        [Required(ErrorMessage = "Voornaam")]
        public string Voornaam { get; set; }
        [Required(ErrorMessage = "Adres")]
        public string Adres { get; set; }
        [Required(ErrorMessage = "Postcode")]
        public string Postcode { get; set; }
        [Required(ErrorMessage = "Gemeente")]
        public string Gemeente { get; set; }
        [Required(ErrorMessage = "Email")]
        [RegularExpression(@"^.+@.+\..+$", ErrorMessage = "Geen geldig e-mailadres")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Telefoon")]
        public string Telefoon { get; set; }
    }
}
