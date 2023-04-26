using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_1
{
    class Program
    {
        static void NextTask()
        {
            Console.WriteLine("\n Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
            Console.Clear();
        }

        static void Main(string[] args)
        {
            /*
             * Создать объект типа MagazineCollection. Добавить в коллекцию несколько
                элементов типа Magazine с разными значениями полей и вывести объект
                MagazineCollection.
             */
            var magazineCollection = new MagazineCollection();

            var firstMagazine = TestCollections.GenerateMagazine(1);
            firstMagazine.ReleaseDate = new DateTime(2023, 4, 26);
            firstMagazine.EditionCirculation = 5;

            var secondMagazine = TestCollections.GenerateMagazine(2);
            secondMagazine.ReleaseDate = new DateTime(2023, 2, 10);
            secondMagazine.EditionCirculation = 10;

            magazineCollection.AddMagazines(firstMagazine, secondMagazine);

            Console.WriteLine(magazineCollection.ToShortString());

            NextTask();

            /*
             * Для созданного объекта MagazineCollection вызвать методы,
                выполняющие сортировку списка List<Magazine> по разным критериям, и
                после каждой сортировки вывести данные объекта. Выполнить
                сортировку
             */

            // по названию издания
            Console.WriteLine("Сортировка по названию издания");
            magazineCollection.SortByName();
            Console.WriteLine(magazineCollection.ToShortString());

            NextTask();

            // по дате выхода издания
            Console.WriteLine("Сортировка по дата выхода издания");
            magazineCollection.SortByDate();
            Console.WriteLine(magazineCollection.ToShortString());

            NextTask();

            // по тиражу издания
            Console.WriteLine("Сортировка по тиражу издания");
            magazineCollection.SortByEditionCirculation();
            Console.WriteLine(magazineCollection.ToShortString());

            NextTask();

            /*
             * Вызвать методы класса MagazineCollection, выполняющие операции со
                списком List<Magazine>, и после каждой операции вывести результат
                операции. Выполнить
             */
            // вычисление максимального значения среднего рейтинга статей для элементов списка; вывести максимальное значение;
            Console.WriteLine("Максимального значения среднего рейтинга статей");
            Console.WriteLine(magazineCollection.MaxAverageRating);
            NextTask();
        }
    }
}
