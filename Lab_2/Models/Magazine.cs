using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class Magazine : Edition, IRateAndCopy
    {
        /* Переодичность выхода журнала */
        private EnumFrequency qutputFrequency;
        /* Редакторы журнала */
        private ArrayList editors;
        /* Cписок статей в журнале */
        private ArrayList articles;

        /* Переодичность выхода журнала */
        public EnumFrequency QutputFrequency
        {
            get { return qutputFrequency; }
            set { qutputFrequency = value; }
        }

        /* Статьи в журнале */
        public ArrayList Articles
        {
            get { return articles; }
            set { articles = value; }
        }
        /* Редакторы журнала */
        public ArrayList Editors
        {
            get { return editors; }
            set { editors = value; }
        }

        /* Cреднее значение рейтинга в списке статей */
        public double AvgRatingOfArticles
        {
            get
            {
                var _articles = from Article article in Articles select article;

                return _articles.Sum(a => a.Rating) / _articles.Count();
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

        /* Строка с информацией о статьях */
        private string ArticlesInfoString
        {

            get {
                var _articles = from Article article in Articles select article;
                return _articles.Select((article) => article.ToString()).Aggregate((current, next) => current + "\n\n" + next); 
            }
        }

        /* Строка с информацией о редакторах */
        private string EditorsInfoString
        {
            get
            {
                var _editors = from Person editor in Editors select editor;
                return _editors.Select((editor) => editor.ToString()).Aggregate((current, next) => current + "\n\n" + next);
            }
        }

        /* Рейтинг всех статей */
        public double Rating
        {
            get
            {
                var _articles = from Article article in Articles select article;
                return _articles.Sum((article) => article.Rating);
            }
        }

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
                var article = Articles[i] as Article;
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
                var article = Articles[i] as Article;
                if (article.Name.Contains(substring))
                {
                    yield return article;
                }
            }
        }


        public Magazine(string name, EnumFrequency qutputFrequency, DateTime releaseDate, int circulation, ArrayList articles, ArrayList editors)
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
            articles = new ArrayList() { new Article(), new Article() };
            editors = new ArrayList() { new Person(), new Person() };
        }
        /* Добавляем статьи в журнал */
        public void AddArticles(params Article[] newArticles)
        {
            var _articles = from Article article in Articles select article;
            
            var concatValues = _articles.Concat(newArticles).ToArray();
            var result = new ArrayList();
            for (int i = 0; i < concatValues.Length; i++)
                result.Add(concatValues[i]);

            articles = result;
        }

        /* Добавляем редакторов в журнал */
        public void AddEditors(params Person[] newEditors)
        {
            var _editors = from Person editor in Editors select editor;

            var concatValues = _editors.Concat(newEditors).ToArray();

            var result = new ArrayList();
            for (int i = 0; i < concatValues.Length; i++)
                result.Add(concatValues[i]);

            editors = result;
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
