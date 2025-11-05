using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemo
{
    internal class Student
    {
        public string firstName;
        public string lastName;
        public int Result1 { get; set; }
        public int Result2 { get; set; }
        public int Result3 { get; set; }

        public Student()
        {

        }

        public double Result(int total)
        {
            return (double)((Result1 + Result2 + Result3) / 3) / 20 * double.Parse(total.ToString());
        }

        //public int Result
        //{
        //    get
        //    {
        //        return (Result1 + Result2 + Result3) / 3;
        //    }
        //}

        public int Age => DateTime.Now.Year - _birthYear; // prop met enkel getter

        public bool IsSucceeded { get; set; }

        private int _birthYear;
        public int BirthYear
        {
            set
            {
                if (value < 1950 || value > 2007)
                    _birthYear = DateTime.Now.Year;
                else
                    _birthYear = value;
            }
        }

        public override string ToString()
        {
            return firstName + " " + lastName;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Student stud)
            {
                return stud.lastName == lastName;
            }
            return false;
        }
    }
}
