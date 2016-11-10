using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsDB
{
    class Person : IComparable
    {
        public String Name { get; set; }
        public String Surname { get; set; }
        public long Pesel { get; set; }

        public Person(String Name, String Surname, long pesel)
        {
            this.Name = Name;
            this.Surname = Surname;
            Pesel = pesel;
        }

        public override string ToString()
        {
            return Name + " " + Surname + ", " + Pesel;
        }

        public int CompareTo(object obj)
        {
            if (!(obj is Person)) return 0;
            Person o = (Person)obj;
            return Math.Sign(this.Pesel - o.Pesel);
        }
    }

    class NamePersonComparer : IComparer<Person>
    {
        /*public int Compare(object x, object y)
        {
            throw new NotImplementedException();
        }
        */
        public int Compare(Person x, Person y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
}
