using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Broodjeszaak.Models
{
    internal class Broodje
    {
        public string Name { get; set; }
        private string _type;

        public string Type
        {
            get { return _type; }
            set {
                if (Array.Exists(_allowedTypes, type => type.Equals(value)))
                {
                    _type = value;
                }
                else
                {
                    throw new ArgumentException("Ongeldig type");
                }
            }
        }

        public decimal Price { get; set; }
        private readonly string[] _allowedTypes = { "warm", "koud", "veggie", "speciaal" };
        
        public Broodje(string name,string type,decimal price)
        {
            Name = name;
            Type = type;
            Price = price;
        }
    }
}
