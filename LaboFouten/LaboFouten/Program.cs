using System;
using LaboFouten;

namespace LaboFouten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welkom bij FitLife!");
            Console.WriteLine("Schrijf je in via onderstaande formulier.");
            Console.WriteLine();
            Console.Write("Naam: ");
            string name = "";
            if (Console.ReadLine().Length != 0)
            {
                name = Console.ReadLine();
            }

            Console.Write("Lengte in meter: ");
            double.TryParse(Console.ReadLine(), out double height);

            Console.Write("Gewicht in kg: ");
            double.TryParse(Console.ReadLine(), out double weight);

            Console.Write("Datum eerste training: ");
            DateTime.TryParse(Console.ReadLine(), out DateTime training);

            //Print summary:
            Console.Clear();
            Console.Write("Bedankt {name}, controleer je gegevens nog een laatste keer:");
            Console.WriteLine($"Naam:   \t {name}");
            Console.WriteLine($"Lengte: \t {weight:f2}m");
            Console.WriteLine($"Gewicht:\t {height:f2}kg");
            Console.WriteLine($"Start:  \t {training.ToString()}");

            Console.WriteLine("Druk op een toets om je lidmaatschap te activeren...");
            Console.ReadKey(true);

            Member member;
            try
            {
                member = new Member(name, height, weight);
            }
            catch (Exception e)
            {
                Console.WriteLine("Fout bij aanmaken lidmaatschap: " + e.Message); return;
            }

            try { member.ActivateMembership(training); }
            catch (Exception e)
            {
                Console.WriteLine("Fout bij activeren lidmaatschap: " + e.Message); return;
            }

            Console.WriteLine($"Lidmaatschap succesvol geactiveerd voor {member.Name} op {member.StartDate}.");
            Console.WriteLine("Druk op een toets om verder te gaan...");
            Console.ReadKey(true);

            bool close = true;

            do
            {
                Console.Clear();
                Console.WriteLine($"Welkom bij FitLife {member.Name}!");
                Console.WriteLine("Beheer hier je lidmaatschap");
                Console.WriteLine();
                Console.WriteLine("1. Lidmaatschap verlengen");
                Console.WriteLine("2. Lidmaatschap stopzetten");
                Console.Write("Selecteer de gewenste optie: ");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Write("Met hoeveel jaar wilt u uw lidmaatschap verlengen? (1 of 2 jaar): ");
                        int.TryParse(Console.ReadLine(), out int years);
                        try { member.RenewMembership(years); }
                        catch (Exception e)
                        {
                            Console.WriteLine("Fout bij verlengen lidmaatschap: " + e.Message); break;
                        }
                        Console.WriteLine($"Proficiat {member.Name}, jouw lidmaatschap is verlengd tot {member.ValidUntil}");
                        break;
                    case "2":
                        Console.Write("Datum stopzetting: ");
                        DateTime.TryParse(Console.ReadLine(), out DateTime endDate);
                        try { member.DeactivateMembership(endDate); }
                        catch (Exception e)
                        {
                            Console.WriteLine("Fout bij stopzetten lidmaatschap: " + e.Message); break;
                        }
                        break;
                    default:
                        close = false;
                        break;
                }

            } while (close);
        }
    }
}
