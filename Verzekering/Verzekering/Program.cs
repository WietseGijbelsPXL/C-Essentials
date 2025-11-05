namespace Verzekering
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int leeftijd;
            string gewest;
            bool roker;
            int bedrag;

            Console.Write("leeftijd: ");
            int.TryParse(Console.ReadLine(), out leeftijd);
            Console.Write("\ngewest: ");
            gewest = Console.ReadLine();
            Console.Write("\nRookt u: ");
            if (Console.ReadLine() == "ja")
            {
                roker = true;
            }
            else
            {
                roker = false;
            }

            if (leeftijd < 18)
            {
                bedrag = 0;
            }
            else if (leeftijd < 67)
            {
                bedrag = 150;
            }
            else
            {
                bedrag = 300;
            }

            bedrag = (gewest.ToLower() == "brussel") ? bedrag + 200 : bedrag;
        
            bedrag = (roker == true) ? bedrag * 2  : bedrag;

            Console.WriteLine($"u moet {bedrag} betalen");
            Console.ReadLine();
        }
    }
}
