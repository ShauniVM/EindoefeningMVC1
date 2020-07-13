using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EindoefeningMVC1.Models;

namespace EindoefeningMVC1.Services
{
    public class PersoonService
    {
        public Persoon Persoon { get; set; }

        public void Add(Persoon p)
        {
            Persoon = p;
        }

    }
}
