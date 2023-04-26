using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    class Magazine
    {
        /* Название журнала */
        private string name;
        /* Переодичность выхода журнала */
        private EnumFrequency qutputFrequency;
        /* Дата выхода журнала */
        private DateTime releaseDate;
        /*  Тираж журнала */
        private int circulation;
        /* Статьи в журнале */
        private Article[] articles;

        /* Название журнала */
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /* Переодичность выхода журнала */
        public EnumFrequency QutputFrequency
        {
            get { return qutputFrequency; }
            set { qutputFrequency = value; }
        }

        /* Дата выхода журнала */
        public DateTime ReleaseDate
        {
            get { return releaseDate; }
            set { releaseDate = value; }
        }
        /*  Тираж журнала */
        public int Circulation
        {
            get { return circulation; }
            set { circulation = value; }
        }

        /* Статьи в журнале */
        public Article[] Articles
        {
            get { return articles; }
            set { articles = value; }
        }

        /* Cреднее значение рейтинга в списке статей */
        public double AvgRatingOfArticles
        {
            get
            {
                return Articles.Sum(a => a.Rating) / Articles.Length;
            }
        }

        public bool this[EnumFrequency frequency]
        {
            get => QutputFrequency == frequency;
        }

        /* Получаем строковое представление частоты выхода журнала */
        private string QutputFrequencyString
        {
            get
            {
                switch (qutputFrequency)
                {
                    case EnumFrequency.Weekly:
                        return "Ежедневно";
                    case EnumFrequency.Monthly:
                        return "Ежемесячно";
                    case EnumFrequency.Yearly:
                        return "Ежегодно";
                    default:
                        return "";
                }
            }
        }

        /* Получаем строку с информацией о статьях */
        private string ArticlesInfoString
        {
            get { return articles.Select((article) => article.ToString()).Aggregate((current, next) => current + "\n\n" + next); }
        }


        public Magazine(string name, EnumFrequency qutputFrequency, DateTime releaseDate, int circulation, Article[] articles)
        {
            this.name = name;
            this.qutputFrequency = qutputFrequency;
            this.releaseDate = releaseDate;
            this.circulation = circulation;
            this.articles = articles;
        }

        public Magazine()
        {
            name = "Тестовый журнал";
            qutputFrequency = EnumFrequency.Monthly;
            releaseDate = DateTime.MinValue;
            circulation = 0;
            articles = new Article[2] { new Article(), new Article() };
        }

        public void AddArticles(params Article[] newArticles)
        {
            articles = articles.Concat(newArticles).ToArray();
        }

        public override string ToString()
        {
            return $"Название журнала: {name}\n" +
                   $"Периодичность выхода журнала: {QutputFrequencyString}\n" +
                   $"Дата выхода журнала: {releaseDate}\n" +
                   $"Тираж: {circulation}\n\n" +
                   $"Статьи:\n" +
                   $"{ArticlesInfoString}";
        }

        public virtual string ToShortString()
        {
            return $"Название журнала: {name}\n" +
                   $"Периодичность выхода журнала: {QutputFrequencyString}\n" +
                   $"Дата выхода журнала: {releaseDate}\n" +
                   $"Тираж: {circulation}\n" +
                   $"Cреднее значение рейтинга статей: {AvgRatingOfArticles}";
        }
    }
}
