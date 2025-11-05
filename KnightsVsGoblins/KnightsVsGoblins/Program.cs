namespace KnightsVsGoblins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            int knightHeatlth =0;
            int goblinHealth = random.Next(0,100);

            Console.WriteLine("Welcome to Knights vs Goblins!\n");
            do
            {
                Console.Write("Enter health points for your knight (1-100):");
                int.TryParse(Console.ReadLine(), out knightHeatlth);
                if (knightHeatlth < 1 || knightHeatlth > 100)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 100.");
                    Console.ResetColor();
                }
            }
            while (knightHeatlth < 1 || knightHeatlth > 100);

            Console.ForegroundColor= ConsoleColor.Blue;
            Console.WriteLine($"knight health: {knightHeatlth}");
            Console.WriteLine($"goblin health: {goblinHealth}");
            Console.ResetColor();

            while (knightHeatlth > 0 && goblinHealth > 0)
            {
                Console.Write("\nChoose your action:");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n1 Attack: deal 10 damage");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("2 Heal: hael 10 heatlh");
                Console.ResetColor();
                Console.Write("Choose your action: ");

                int.TryParse(Console.ReadLine(), out int action);

                switch (action)
                {
                    case 1:
                        int knightAttack = 10;
                        int goblinAttack = random.Next(5,16);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"\nYou attacked the goblin for {knightAttack} damage!");
                        goblinHealth -= knightAttack;
                        Console.WriteLine($"The goblin attacked you for {goblinAttack} damage!");
                        knightHeatlth -= goblinAttack;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"\nkinght health: {knightHeatlth}");
                        Console.WriteLine($"goblin health: {goblinHealth}");
                        Console.ResetColor();
                        break;
                    case 2:
                        goblinAttack = random.Next(5, 16);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\nYou attacked the goblin for 10 health!");
                        knightHeatlth += 10;
                        Console.ForegroundColor= ConsoleColor.Red;
                        Console.WriteLine($"The goblin attacked you for {goblinAttack} damage!");
                        knightHeatlth -= goblinAttack;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"\nkinght health: {knightHeatlth}");
                        Console.WriteLine($"goblin health: {goblinHealth}");
                        Console.ResetColor();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nNot a valid action, you lose 5 health!");
                        knightHeatlth -= 5;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"\nkinght health: {knightHeatlth}");
                        Console.WriteLine($"goblin health: {goblinHealth}");
                        Console.ResetColor();
                        break;
                }
            }
            if(knightHeatlth <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nDefeat, you where slain!");
                Console.ResetColor();
                Console.WriteLine("\nPress any key to exit...");
                Console.ReadKey();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Victory, you defeaeted tthe goblin!");
                Console.ResetColor();
                Console.WriteLine("\nPress any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
