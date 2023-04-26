using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_1
{
    class Edition : IComparable, IComparable<Edition>
    {
        /* Название издания */
        protected string name;
        /* Дата выхода издания */
        protected DateTime releaseDate;
        /* Тираж издания */
        protected int editionCirculation;

        /* Название издания */
        public string Name { 
            get { return name; }
            set { name = value; }
        }
        /* Дата выхода издания */
        public DateTime ReleaseDate { 
            get { return releaseDate; }
            set { releaseDate = value; }
        }
        /* Тираж издания */
        public int EditionCirculation { 
            get { return editionCirculation; }
            set { 
                if(value < 0)
                {
                    Exception exception = new Exception("EditionCirculation < 0");
                    throw exception;
                }
                editionCirculation = value;
            }
        }

    
        public Edition(string name, DateTime releaseDate, int editionCirculation)
        {
            this.name = name;
            this.releaseDate = releaseDate;
            this.editionCirculation = editionCirculation;
        }

        public Edition()
        {
            name = "Тестовое издание";
            releaseDate = new DateTime();
            editionCirculation = 99;
        }

        public virtual object DeepCopy()
        {
            return new Edition(Name, releaseDate, editionCirculation);
        }

        public override bool Equals(object obj)
        {
            var edition = obj as Edition;
            return name == edition.Name && releaseDate == edition.ReleaseDate && editionCirculation == edition.editionCirculation;
        }

        public override string ToString()
        {
            return $"Название издания: {name}\n" +
                   $"Дата выхода издания: {releaseDate}\n" +
                   $"Тираж издания: {editionCirculation}";
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public int CompareTo(object o)
        {
            if (o is Edition edition) return Name.CompareTo(edition.Name);
            else throw new ArgumentException("Некорректное значение параметра");
        }

        public int CompareTo(Edition edition)
        {
            return ReleaseDate.CompareTo(edition.ReleaseDate);
        }
    }
}
