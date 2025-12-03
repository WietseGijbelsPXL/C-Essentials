using HR_app.Models;
namespace HR_app
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Voornaam: ");
            string firstName = Console.ReadLine();

            Console.Write("Achternaam: ");
            string lastName = Console.ReadLine();

            Console.Write("Geboortedatum: ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Salaris: ");
            decimal salary = decimal.Parse(Console.ReadLine());

            Employee employee = new Employee(firstName, lastName);
            employee.BirthDate = birthDate;
            employee.Salary = salary;

            Console.WriteLine(ShowDetails(employee));
            Console.Write("Oplsag percentage: ");
            int percentage = int.Parse(Console.ReadLine());
            employee.IncreaseSalary(percentage);
            Console.WriteLine(ShowDetails(employee));
        }

        static string ShowDetails(Employee employee)
        {
            return $"--------------------------------------------\nWerknemer: {employee.FirstName} {employee.LastName}\nGeboortedatum: {employee.BirthDate.ToString("dddd dd MMMM yyyy")} ({employee.Age})\nSalaris: € {employee.Salary}\n--------------------------------------------\nSamenvatting: {employee.ToString()}\n--------------------------------------------";
        }
    }
}
