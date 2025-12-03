using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboFouten
{
    public class Member
    {
        public Member(string name, double height, double weight)
        {
            if (name == null)
            {
                throw new ArgumentNullException("Naam mag niet leeg zijn!");
            }
            if ( height > 1 && height < 3)
            {
                throw new ArgumentOutOfRangeException("Lengte moet tussen 1m en 3m liggen!");
            }
            if ( weight > 40 && weight < 200)
            {
                throw new ArgumentOutOfRangeException("Gewicht moet tussen 40kg en 200kg liggen!");
            }
            
            Name = name;
            Height = height;
            Weight = weight;
        }

        public string Name { get; }
        public double Height { get; }
        public double Weight { get; }
        public DateTime StartDate { get; set; }
        public DateTime ValidUntil { get; set; }

        private bool IsActive()
        {
            if (StartDate < DateTime.Today && ValidUntil > DateTime.Today)
            {
                return true;
            }

            return false;
        }

        public void ActivateMembership(DateTime startDate)
        {
            if (IsActive())
            {
                throw new Exception("Het lidmaatschap van lid {Name} kan niet geactiveerd worden omdat het is al actief is!");
            }
            else if(startDate.AddYears(1) < DateTime.Today)
            {
                throw new Exception("Het lidmaatschap van lid {Name} kan niet geactiveerd worden omdat de startdatum meer dan een jaar geleden is!");
            }
            else if(DateTime.Today.AddMonths(1) < startDate)
            {
                throw new Exception("Het lidmaatschap van lid {Name} kan niet geactiveerd worden omdat de startdatum meer dan een maand in de toekomst ligt!");
            }

            StartDate = startDate;
            ValidUntil = startDate.AddYears(1);
        }

        public void RenewMembership(int years)
        {
            if (!IsActive())
            {
                throw new Exception("Het lidmaatschap van lid {name} kan niet verlengd worden omdat dit niet actief is!");
            }
            else if((ValidUntil - DateTime.Today).TotalDays > 30)
            {
                throw new Exception("Het lidmaatschap van lid {Name} kan niet verlengd worden omdat het nog meer dan 30 dagen actief is!");
            }
            else if(years != 1 && years != 2)
            {
                throw new Exception("Het lidmaatschap van lid {Name} kan enkel verlengd worden met 1 of 2 jaar!");
            }
            ValidUntil = ValidUntil.AddYears(years);
        }

        public void DeactivateMembership(DateTime endDate)
        {
            if (!IsActive())
            {
                throw new Exception("Het lidmaatschap van lid {Name} kan niet gestopt worden omdat het niet actief is!");
            }
            else if( (ValidUntil - endDate).TotalDays > 60)
            {
                throw new Exception("Het lidmaatschap van lid {Name} kan niet gestopt worden omdat het nog meer dan 60 dagen actief is!");
            }

                ValidUntil = endDate;
        }

        public Member CreateFake()
        {
            StartDate = DateTime.Today;
            ValidUntil = DateTime.Today;
            return new Member("Jan Jansen", 1.80, 75);
        }
    }
}
