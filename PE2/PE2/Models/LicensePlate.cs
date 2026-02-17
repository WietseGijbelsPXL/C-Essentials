using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE2.Models
{
    class LicensePlate
    {
        List<ChargeSession> chargeSessions = new List<ChargeSession>();

        public List<ChargeSession> ChargeSessions
        {
            get
            {
                return chargeSessions;
            }
            set
            {
                chargeSessions = value;
            }
        }
        public Customer Customer { get; set; }
        public int Mileage { get; set; }
        public string Plate { get; set; }

        public override string ToString()
        {
            return $"{Plate} ({Mileage} km)";
        }

        public string ShowChargingSessions()
        {
            StringBuilder sb = new StringBuilder();
            foreach (ChargeSession chargeSession in chargeSessions)
            {
                sb.Append(chargeSession.ToString());
                sb.Append("\n");
            }
            return sb.ToString();
        }
    }
}
