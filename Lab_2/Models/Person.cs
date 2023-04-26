using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class Person
    {
        /* Имя */
        private string name;
        /* Фамилия */
        private string secondName;
        /*  Дата рождения */
        private DateTime dateBirth;

        /** Имя */
        public string Name
        {
            get { return name; }
        }
        /* Фамилия */
        public string SecondName
        {
            get { return secondName; }
        }
        /*  Дата рождения */
        public DateTime DateBirth
        {
            get { return dateBirth; }
        }

        public int DateBirthYear
        {
            get { return dateBirth.Year; }
            set { dateBirth.AddYears(value - dateBirth.Year); }
        }


        public Person(string name, string secondName, DateTime dateBirth)
        {
            this.name = name;
            this.secondName = secondName;
            this.dateBirth = dateBirth;
        }

        public Person()
        {
            name = "Егор";
            secondName = "Дмитриев";
            dateBirth = new DateTime(1999, 1, 1);
        }

        public override string ToString()
        {
            return $"Имя: {Name}\nФамилия: {SecondName}\nДата рождения: {DateBirth}";
        }

        public virtual string ToShortString()
        {
            return $"Имя: {Name}\nФамилия: {SecondName}";
        }

        public override bool Equals(object obj)
        {
            var person = obj as Person;
            return name == person.name && secondName == person.secondName && dateBirth == person.dateBirth;
        }

        public static bool operator ==(Person obj1, Person obj2)
        {
            return obj1.Equals(obj2);
        }
        public static bool operator !=(Person obj1, Person obj2)
        {
            return !obj1.Equals(obj2);
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public Person DeepCopy()
        {
            return new Person(Name, SecondName, DateBirth);
        }
    }
}
