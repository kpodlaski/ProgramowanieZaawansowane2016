using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsDB
{
    class Student : Person
    {
        public int Index { get; set; }
        public int Semester { get; set; }
        private static int lastIndex = 1;
        public Student(string Name, string Surname, long pesel) 
            : base(Name, Surname, pesel)
        {
            Semester = 1;
            Index = ++lastIndex;
        }
    }
}
