namespace Rekenmachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int getal1;
            int getal2;
            int uitkomst;

            int.TryParse(Console.ReadLine(), out getal1);
            int.TryParse(Console.ReadLine(), out getal2);

            string teken = Console.ReadLine();

            switch (teken)
            {
                case ("+"):
                    uitkomst = getal1 + getal2;
                    break;
                case ("-"):
                    uitkomst = getal1 - getal2;
                    break;
                case ("*"):
                    uitkomst = getal1 * getal2;
                    break;
                case ("/"):
                    uitkomst = getal1 / getal2;
                    break;
                default:
                    uitkomst = 0;
                    break;
            }
            Console.WriteLine(uitkomst);
        }
    }
}
