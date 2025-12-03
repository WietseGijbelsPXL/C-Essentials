using Broodjeszaak.Models;

namespace Broodjeszaak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Broodje> broodjes = new List<Broodje>();
            Dictionary<string, decimal> omzet = new Dictionary<string, decimal>();

            while (true)
            {
                Console.Write("Naam broodje: ");
                string name = Console.ReadLine();
                if (name == "stop")
                {
                    break;
                }
                
                Console.WriteLine("Geldige types: warm, koud, veggie, speciaal");
                Console.Write("Type broodje: ");
                string type = Console.ReadLine();
                
                Console.Write("Prijs broodje: ");
                decimal.TryParse(Console.ReadLine(), out decimal price);
                
                try
                {
                    broodjes.Add(new Broodje(name, type, price));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
                if (!omzet.ContainsKey(type))
                {
                    omzet.Add(type, price);
                }
                else
                {
                    omzet[type] += price;
                }
                Console.WriteLine();
            }
            
            Console.WriteLine();
            
            foreach (Broodje broodje in broodjes)
            {
                Console.WriteLine($"{broodje.Name} {broodje.Type} {broodje.Price}");
            }
            
            Console.WriteLine("\nomzet per type");
            
            foreach(var entry in omzet)
            {
                Console.WriteLine($"{entry.Key} {entry.Value}");
            }
        }
    }
}
