namespace FirstConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstName;
            string lastName;
            int birthYear;
            int age;

            Console.WriteLine("First App");
            Console.WriteLine("Wat is je naam?");
            firstName = Console.ReadLine();
            Console.WriteLine("Wat is je achternaam?");
            lastName = Console.ReadLine();
            Console.WriteLine("Wat is je geboortejaar?");
            int.TryParse(Console.ReadLine(), out birthYear);

            age = DateTime.Today.Year - birthYear;
            Console.WriteLine($"{firstName} {lastName} ({age} jaar)"); 
        }
    }
}
