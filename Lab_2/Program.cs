using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class Program
    {
        const string SEPARATOR_START = "-----------------------------------------------------------------";
        const string SEPARATOR_END = "-----------------------------------------------------------------\n\n\n";

        static void TestArraysRunTime<T>(T item, int nrow, int ncolumn)
        {
            /* Одномерный массив */
            T[] OneDimArray = new T[nrow * ncolumn];
            /* Двумерный массив */
            T[,] TwoDimArray = new T[nrow, ncolumn];
            /* Ступенчатый массив */
            T[][] StepArray = new T[nrow][];


            /* Заполняем ступенчатый массив другими массивами */
            for (int i = 0; i < StepArray.Length; i++)
                StepArray[i] = new T[ncolumn];


            int OneDimTimeStart = Environment.TickCount;

            /* Заполняем одномерный массив */
            for (int i = 0; i < OneDimArray.Length; i++)
                OneDimArray[i] = item;

            int OneDimTimeEnd = Environment.TickCount;
            Console.WriteLine($"Одномерный массив: {OneDimTimeEnd - OneDimTimeStart}");
            int TwoDimTimeStart = Environment.TickCount;

            /* Заполняем двумерный массив */
            for (int i = 0; i < TwoDimArray.GetLength(0); i++)
                for (int j = 0; j < TwoDimArray.GetLength(1); j++)
                    TwoDimArray[i, j] = item;

            int TwoDimTimeEnd = Environment.TickCount;
            Console.WriteLine($"Двумерный массив: {TwoDimTimeEnd - TwoDimTimeStart}");
            int StepTimeStart = Environment.TickCount;

            /* Заполняем ступенчатый массив */
            for (int i = 0; i < StepArray.Length; i++)
                for (int j = 0; j < StepArray[i].Length; j++)
                    StepArray[i][j] = item;

            int StepTimeEnd = Environment.TickCount;
            Console.WriteLine($"Ступенчатый массив: {StepTimeEnd - StepTimeStart}");
        }
        static void StartLab_2()
        {
            Console.WriteLine("Задание №1");
            Console.WriteLine(SEPARATOR_START);
            /*
             *  Создать два объекта типа Edition с совпадающими данными и проверить,
             *  что ссылки на объекты не равны, а объекты равны, вывести значения хэш-
             *  кодов для объектов.
             */
            var first = new Edition("First", new DateTime(), 10);
            var second = new Edition("First", new DateTime(), 10);
            Console.WriteLine($"Проверка ссылок на объекты (first == second): {first == second}");
            Console.WriteLine($"Equals: {first.Equals(second)}");
            Console.WriteLine($"First Hash: {first.GetHashCode()}; Second Hash: {second.GetHashCode()}");
            Console.WriteLine(SEPARATOR_END);

            Console.WriteLine("Задание №2");
            Console.WriteLine(SEPARATOR_START);

            /*
             * В блоке try/catch присвоить свойству с тиражом издания некорректное
             * значение, в обработчике исключения вывести сообщение, переданное
             * через объект-исключение.
             */
            try
            {
                first.EditionCirculation = -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.WriteLine(SEPARATOR_END);

            Console.WriteLine("Задание №3");
            Console.WriteLine(SEPARATOR_START);

            /*
             *  Создать объект типа Magazine, добавить элементы в списки статей и
             *  редакторов журнала и вывести данные объекта Magazine.
             */
            var magazine = new Magazine();
            magazine.AddArticles(new Article(new Person("Петров", "Иванович", new DateTime()), "Статья №2342", 23));
            magazine.AddEditors(new Person("Петр", "Васильевич", new DateTime()));
            Console.WriteLine(magazine);
            Console.WriteLine(SEPARATOR_END);

            Console.WriteLine("Задание №4");
            Console.WriteLine(SEPARATOR_START);

            /*
             * Вывести значение свойства типа Edition для объекта типа Magazine.
             */
            Console.WriteLine(magazine.Edition);
            Console.WriteLine(SEPARATOR_END);

            Console.WriteLine("Задание №5");
            Console.WriteLine(SEPARATOR_START);

            /*
             * С помощью метода DeepCopy() создать полную копию объекта Magazine.
             * Изменить данные в исходном объекте Magazine и вывести копию и
             * исходный объект, полная копия исходного объекта должна остаться без
             * изменений.
             */
            var newMagazine = magazine.DeepCopy() as Magazine;
            newMagazine.Name = "test12345";
            Console.WriteLine(magazine);
            Console.WriteLine(SEPARATOR_END);

            Console.WriteLine("Задание №6");
            Console.WriteLine(SEPARATOR_START);
            /*
             * С помощью оператора foreach для итератора с параметром типа double
             * вывести список всех статей с рейтингом больше некоторого заданного
             * значения.
             */
            foreach (Article article in magazine.GetArticlesForRating(10))
            {
                Console.WriteLine(article + "\n");
            }
            Console.WriteLine(SEPARATOR_END);

            Console.WriteLine("Задание №7");
            Console.WriteLine(SEPARATOR_START);
            /*
             *  С помощью оператора foreach для итератора с параметром типа string
             *  вывести список статей, в названии которых есть заданная строка.
             */
            foreach (Article article in magazine.GetArticlesForSubstr("ест"))
            {
                Console.WriteLine(article + "\n");
            }
            Console.WriteLine(SEPARATOR_END);

        }
        static void Main(string[] args)
        {
            StartLab_2();
            Console.ReadLine();
        }
    }
}
