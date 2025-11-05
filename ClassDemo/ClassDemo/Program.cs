namespace ClassDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student std = new Student();
            std.firstName = "Wietse";
            std.lastName = "Gijbels";
            std.BirthYear = -2000;
            std.Result1 = 9;
            std.Result2 = 15;
            std.Result3 = 15;

            Student std2 = new Student();
            std2.firstName = "Kaat";
            std2.lastName = "Gijbels";

            Console.WriteLine(std);
            Console.WriteLine(std2);
            Console.WriteLine(std.Equals(std2));
        }
    }
}
