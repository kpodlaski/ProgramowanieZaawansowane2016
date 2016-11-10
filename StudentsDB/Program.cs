using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Student[] students = new Student[5];
            students[0] = new Student("Adam","Adamski",88031207654);
            students[1] = new Student("Ewa", "Jagoda", 98052277654);
            students[2] = new Student("Tamara", "Mąka", 02250377654);
            students[4] = new Student("Tomasz", "Mąka", 99102527654);
            students[3] = new Student("Elżbieta", "Wąsik", 79110117654);
            foreach (Person p in students)
            {
                Console.WriteLine(p);   
            }
            Console.WriteLine("::::SORTUJE::::");
            sortPersons2(students);
            foreach (Person p in students)
            {
                Console.WriteLine(p);
            }
            Console.Read();
        }

        static void sortPersons1(Person[] p)
        {
            //Posortować według daty urodzenia
            Array.Sort(p);
            
        }

        static void sortPersons2(Person[] p)
        {
            //Posortować według daty urodzenia
            Array.Sort(p,new NamePersonComparer());

        }
    }
}
