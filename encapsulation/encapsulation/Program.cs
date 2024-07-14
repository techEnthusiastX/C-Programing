using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace encapsulation
{
    class Person
    {
        private string name;
        private int age;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.Name = "Harshad";
            person.Age = 20;

            Console.WriteLine("Name: " + person.Name);
            Console.WriteLine("Age: " + person.Age);

            Console.ReadLine();
        }
    }

    
}
