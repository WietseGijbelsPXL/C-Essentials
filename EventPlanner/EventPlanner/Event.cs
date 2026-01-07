using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace EventPlanner
{
    class Event
    {
        public string Type { get; set; }
        public string Naam { get; set; }
        public int AantalBezoekers { get; set; }

        public Event(string type, string naam, int aantalBezoekers)
        {
            Type = type;
            Naam = naam;
            AantalBezoekers = aantalBezoekers;
        }

        public override string ToString()
        {
            return $"{Type} - {Naam}: {AantalBezoekers}";
        }
    }
}
