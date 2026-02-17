using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE2.Models
{
    class ChargeSession
    {

        public int Consumption { get; set; }
        public float Price { get; set; }
        public DateTime TimeStamp { get; set; }

        public ChargeSession(int consumption, float price, DateTime timeStamp)
        {
            Consumption = consumption;
            Price = price;
            TimeStamp = timeStamp;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(TimeStamp.ToLongDateString());
            sb.Append(" ~ ");
            sb.Append(Consumption);
            sb.Append(" * € ");
            sb.Append(Price);
            sb.Append(" = ");
            double cost = Math.Round(Price * Consumption,2);
            sb.Append(cost);
            return sb.ToString();
        }
    }
}
