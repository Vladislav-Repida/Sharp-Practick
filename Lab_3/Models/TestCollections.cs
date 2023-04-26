using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_1 {
    class TestCollections
    {
        /* Издатели */
        private List<Edition> editions;
        /* Названия издателей */
        private List<string> editionNames;
        /* Журналы по ключу издателя */
        private Dictionary<Edition, Magazine> editionMagazine;
        /* Журналы по ключу имени издателя */
        private Dictionary<string, Magazine> editionNameMagazine;
        
        /* Генерируем объект Person */
        public static Person GeneratePerson(int i)
        {
            return new Person($"PersonName - {i}", $"PersonSecondName - i", new DateTime());
        }

        /* Генерируем объект Article */
        public static Article GenerateArticle(int i)
        {
            return new Article(GeneratePerson(i), $"Article - {i}", i * 5);
        }

        /* 
         * Генерируем объект класс Magazine
         */
        public static Magazine GenerateMagazine(int i)
        {
            /* Список редакторов */
            List<Person> editors = new List<Person>();

            /* Заполняем список редакторов случайными значениями */
            for (int j = 0; j < 2; j++)
                editors.Add(GeneratePerson(i + j));

            /* Список статей */
            List<Article> articles = new List<Article>();

            /* Заполняе список статеть случайными значениями */
            for (int j = 0; j < 2; j++)
                articles.Add(GenerateArticle(i + j));

            Random random = new Random();
            /* Генерируем рандомное значение enum */
            EnumFrequency frequency = (EnumFrequency)Enum.GetValues(typeof(EnumFrequency)).GetValue(random.Next(1, 3));

            /* Создаем и возвращаем объект Magazine */
            return new Magazine($"Magazine - {i}", frequency, new DateTime(), i * 28, articles, editors);

        }

        public TestCollections(int count)
        {
            /* Издатели */
            editions = new List<Edition>();
            /* Названия издателей */
            editionNames = new List<string>();
            /* Журналы по издателю */
            editionMagazine = new Dictionary<Edition, Magazine>();
            /* Журналы по имени издателя */
            editionNameMagazine = new Dictionary<string, Magazine>();

            for (int i = 0; i < count; i++)
            {
                /* Генерируем журнал */
                var magazine = GenerateMagazine(i);
                /* Добавляем издателя */
                editions.Add(magazine.Edition);
                /* Добавляем имя издателя */
                editionNames.Add(magazine.Name);
                /* Добавляем журнал по издателю */
                editionMagazine.Add(magazine.Edition, magazine);
                /* Добавляем журналы по имени издателя */
                editionNameMagazine.Add(magazine.Name, magazine);
            }
        }

        public void Test(string editionName)
        {
            // Test find List<string>
            int startTimer = Environment.TickCount;
            string edition = editionNames.Find((item) => item == editionName);
            Console.WriteLine($"Test find List<string> - {Environment.TickCount - startTimer}");

            // Test find List<Edition>
            startTimer = Environment.TickCount;
            Edition edition1 = editions.Find((item) => item.Name == editionName);
            Console.WriteLine($"Test find List<Edition> - {Environment.TickCount - startTimer}");

            if(edition1 != null)
            {
                // Test find Dictionary<Edition, Magazine>
                startTimer = Environment.TickCount;
                Magazine magazine = editionMagazine[edition1];
                Console.WriteLine($"Test find  Dictionary<Edition, Magazine> - {Environment.TickCount - startTimer}");
            }

            // Test find Dictionary<string, Magazine>
            startTimer = Environment.TickCount;
            Magazine magazine1 = editionNameMagazine[editionName];
            Console.WriteLine($"Test find Dictionary<string, Magazine> - {Environment.TickCount - startTimer}");
        }
    }
}
