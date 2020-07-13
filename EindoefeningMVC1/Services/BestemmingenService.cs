using EindoefeningMVC1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EindoefeningMVC1.Services
{
    public class BestemmingenService
    {
        public Dictionary<int, BestemmingModel> Bestemmingen = new Dictionary<int, BestemmingModel>();

        public void Add(BestemmingModel bestemming)
        {
            if (Bestemmingen == null)
                bestemming.ID = 1;
            else
                bestemming.ID = Bestemmingen.Keys.Max() + 1;
            Bestemmingen.Add(bestemming.ID, bestemming);
        }

        public List<BestemmingModel> ShowAll()
        {
            return Bestemmingen.Values.ToList();
        }

        public BestemmingModel FindByID(int id)
        {
            return Bestemmingen[id];
        }

        public void Delete(int id)
        {
            Bestemmingen.Remove(id);
        }
    }
}
