using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_1
{
    class Article: IRateAndCopy
    {
        /* Автор статьи */
        public Person Person { get; set; }
        /* Название статьи */
        public string Name { get; set; }
        /* Рейтинг статьи */
        public double Rating { get; set; }

        public Article(Person person, string name, double rating)
        {
            Person = person;
            Name = name;
            Rating = rating;
        }

        public Article()
        {
            Person = new Person();
            Name = "Тестовая статья";
            Rating = 2.1;
        }

        public override string ToString()
        {
            return $"Название статьи: {Name}\nРейтинг статьи: {Rating}\nАвтор статьи: {Person}";
        }

        public object DeepCopy()
        {
            return new Article(Person.DeepCopy(), Name, Rating);
        }
    }
}
