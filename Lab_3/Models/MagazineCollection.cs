using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_1
{
    // Класс, реализующий интерфейс IComparer<Edition> для сортировки по дате выхода
    class EditionDateComparer : IComparer<Magazine>
    {
        public int Compare(Magazine x, Magazine y)
        {
            return x.ReleaseDate.CompareTo(y.ReleaseDate);
        }
    }

    // Класс, реализующий интерфейс IComparer<Edition> для сортировки по тиражу
    class EditionyEditionCirculationComparer : IComparer<Magazine>
    {
        public int Compare(Magazine x, Magazine y)
        {
            return x.EditionCirculation.CompareTo(y.EditionCirculation);
        }
    }
    class NameComparer: IComparer<Magazine>
    {
        public int Compare(Magazine x, Magazine y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }

    class MagazineCollection
    {
        /*
         * Список журналов
         */
        private List<Magazine> magazines = new List<Magazine>();

        // Cвойство, возвращающее максимальное значение среднего рейтинга статей
        public double MaxAverageRating
        {
            get
            {
                if (magazines == null || magazines.Count == 0) return 0;
                return magazines.Max(m => m.AvgRatingOfArticles);
            }
        }

        // Cвойство, возвращающее подмножество элементов с периодичностью выхода журнала Monthly
        public IEnumerable<Magazine> MonthlyMagazines
        {
            get {
                return magazines.Where(m => m.QutputFrequency == EnumFrequency.Monthly);
            }
        }

        // Метод, возвращающий список элементов со средним рейтингом статей больше или равным заданному значению
        public List<Magazine> RatingGroup(double value)
        {
            return magazines.GroupBy(m => m.AvgRatingOfArticles >= value).Where(g => g.Key).SelectMany(g => g).ToList();
        }


        /*
         * Добавляем журналы по умолчанию
         */
        public void AddDefault()
        {
            var article1 = new Article(new Person("Иван", "Федоров", new DateTime(2000, 07, 18)), "Статья №1", 5);
            var article2 = new Article(new Person("Петров", "Сергеевич", new DateTime(2000, 10, 12)), "Статья №2", 10);
            var article3 = new Article(new Person("Александр", "Куприлович", new DateTime(1995, 05, 27)), "Статья №3", 23);

            magazines.Add(new Magazine("Журнал №1", EnumFrequency.Yearly, new DateTime(2020, 09,20), 500, new List<Article> { article1, article2, article3 }, new List<Person> { new Person("Сергей", "Иванов", new DateTime(1999, 10, 14))}));
            magazines.Add(new Magazine("Журнал №2", EnumFrequency.Yearly, new DateTime(2020, 09,20), 500, new List<Article> { article1, article3 }, new List<Person> { new Person("Сергей1", "Иванов1", new DateTime(1999, 10, 14))}));
        }

        /*
         * Добавить журналы
         */
        public void AddMagazines(params Magazine[] _magazines)
        {
            magazines.AddRange(_magazines);
        }

        // Сортировка по названию издания
        public void SortByName()
        {
            magazines.Sort(new NameComparer());
        }

        // Сортировка по дате выхода издания
        public void SortByDate()
        {
            magazines.Sort(new EditionDateComparer());
        }

        // Сортировка по тиражу издания
        public void SortByEditionCirculation()
        {
            magazines.Sort(new EditionyEditionCirculationComparer());
        }

        public override string ToString()
        {
            return magazines.Aggregate("", (acc, next) => acc + "\n===\n" + next.ToString());
        }
        
        public virtual string ToShortString()
        {
            return magazines.Aggregate("", (acc, next) => acc + "\n===\n" + next.ToShortString());
        }
    }
}
