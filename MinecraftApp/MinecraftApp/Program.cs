namespace MinecraftApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int stonePickaxeDurability = 131;
            int ironPickaxeDurability = 250;
            int diamondPickaxeDurability = 1561;
            int netheritePickaxeDurability = 2031;
            int blocksToMine;
            string toolName;
            int maxDurability;

            Console.Write("Hoeveel blokken wil je mijnen? ");
            blocksToMine = int.Parse(Console.ReadLine());
            Console.WriteLine($"\nStone: {stonePickaxeDurability - blocksToMine} durability over");
            Console.WriteLine($"Iron: {ironPickaxeDurability - blocksToMine} durability over");
            Console.WriteLine($"Diamond: {diamondPickaxeDurability - blocksToMine} durability over");
            Console.WriteLine($"Netherite: {netheritePickaxeDurability - blocksToMine} durability over\n");

            Console.Write("Maak je eigen tool - geef een naam: ");
            toolName = Console.ReadLine();
            Console.Write("\nGeef maximale durability (geheel getal): ");
            int.TryParse(Console.ReadLine(), out maxDurability);
            Console.WriteLine($"\nJe tool '{toolName}' heeft nog {maxDurability - blocksToMine} durability over na {blocksToMine} blokken.");
        }
    }
}
