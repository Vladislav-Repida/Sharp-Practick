using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_1
{
    class Magazine : Edition, IRateAndCopy
    {
        /* Переодичность выхода журнала */
        private EnumFrequency qutputFrequency;
        /* Редакторы журнала */
        private List<Person> editors;
        /* Cписок статей в журнале */
        private List<Article> articles;

        /* Переодичность выхода журнала */
        public EnumFrequency QutputFrequency
        {
            get { return qutputFrequency; }
            set { qutputFrequency = value; }
        }

        /* Статьи в журнале */
        public List<Article> Articles
        {
            get { return articles; }
            set { articles = value; }
        }
        /* Редакторы журнала */
        public List<Person> Editors
        {
            get { return editors; }
            set { editors = value; }
        }

        /* Cреднее значение рейтинга в списке статей */
        public double AvgRatingOfArticles
        {
            get
            {
                return articles.Sum(a => a.Rating) / articles.Count();
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

            get {
                return articles.Select((article) => article.ToString()).Aggregate((current, next) => current + "\n\n" + next); 
            }
        }

        /* Строка с информацие о редакторах */
        private string EditorsInfoString
        {
            get
            {
                return editors.Select((editor) => editor.ToString()).Aggregate((current, next) => current + "\n\n" + next);
            }
        }

        /* Рейтинг всех журналов */
        public double Rating
        {
            get
            {
                return articles.Sum((article) => article.Rating);
            }
        }

        /* Данные издателя */
        public Edition Edition
        {
            get
            {
                return new Edition(Name, ReleaseDate, EditionCirculation);
            }
            set
            {
                Name = value.Name;
                ReleaseDate = value.ReleaseDate;
                EditionCirculation = value.EditionCirculation;
            }
        }

        public IEnumerable<Article> GetArticlesForRating(double min = 0) {
            for (int i = 0; i < Articles.Count; i++)
            {
                var article = Articles[i];
                if(article.Rating > min)
                {
                    yield return article;
                }
            }
        }

        public IEnumerable<Article> GetArticlesForSubstr(string substring)
        {
            for (int i = 0; i < Articles.Count; i++)
            {
                var article = Articles[i];
                if (article.Name.Contains(substring))
                {
                    yield return article;
                }
            }
        }


        public Magazine(string name, EnumFrequency qutputFrequency, DateTime releaseDate, int circulation, List<Article> articles, List<Person> editors)
        {
            this.name = name;
            this.qutputFrequency = qutputFrequency;
            this.releaseDate = releaseDate;
            editionCirculation = circulation;
            this.articles = articles;
            this.editors = editors;
        }

        public Magazine()
        {
            name = "Тестовый журнал";
            qutputFrequency = EnumFrequency.Monthly;
            releaseDate = DateTime.MinValue;
            editionCirculation = 0;
            articles = new List<Article>() { new Article(), new Article() };
            editors = new List<Person>() { new Person(), new Person() };
        }
        /* Добавляем статьи в журнал */
        public void AddArticles(params Article[] newArticles)
        {
            articles = articles.Concat(newArticles).ToList();
        }

        /* Добавляем редакторов в журнал */
        public void AddEditors(params Person[] newEditors)
        {
            editors = editors.Concat(newEditors).ToList();
        }

        public override string ToString()
        {
            return $"Название журнала: {name}\n" +
                   $"Периодичность выхода журнала: {QutputFrequencyString}\n" +
                   $"Дата выхода журнала: {releaseDate}\n" +
                   $"Тираж: {editionCirculation}\n\n" +
                   $"Статьи:\n" +
                   $"{ArticlesInfoString}\n\n" +
                   $"Редакторы:\n" +
                   $"{EditorsInfoString}";
        }

        public virtual string ToShortString()
        {
            return $"Название журнала: {name}\n" +
                   $"Периодичность выхода журнала: {QutputFrequencyString}\n" +
                   $"Дата выхода журнала: {releaseDate}\n" +
                   $"Тираж: {editionCirculation}\n" +
                   $"Cреднее значение рейтинга статей: {AvgRatingOfArticles}";
        }

        public override object DeepCopy()
        {
            return new Magazine(Name, QutputFrequency, ReleaseDate, EditionCirculation, Articles, Editors);
        }
    }
}
