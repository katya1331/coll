using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica13.coll
{
    class Student
    {
        private string name;
        private string surname;
        private int bookname = 0;
        public void Set(string name, string surname, int bookname)
        {
            this.name = name;
            this.surname = surname;
            this.bookname = bookname;
        }
        public string getName()
        {
            return name;
        }
        public string getSurname()
        {
            return surname;
        }
        public int Bookname()
        {
            return bookname;
        }
    }
}
