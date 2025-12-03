namespace ArrayDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Wouter", "Paul", "Andreas", "Silvia", "Peter", "Tom", "Anna", "Sven", "Bob" };
            string[] backup = new string[names.Length];

            Array.Sort(names);
            Array.Reverse(names);
            Array.Sort(names, 1, 2);
            Array.Copy(names, backup,names.Length);
            //int idx = Array.IndexOf(names, "Wietse");

            //alle, find doet eerste
            //om te printen steek in string array
            //Array.FindAll(names, StartWithP);
            // hoofdletter gevoelig
            string[] result = Array.FindAll(names, (name) => name.StartsWith("p"));

            Array.Resize(ref names, 10);

            if (Array.Exists(names, n => n.Equals("P")){
                Console.WriteLine("ok");
            }

            //Console.WriteLine(idx);

            foreach (string name in result)
            {
                Console.WriteLine(name);
            }
        }

        static bool StartWithP(string name)
        {
            if (name.StartsWith("P")) return true;
            else return false;
        }
    }
}
