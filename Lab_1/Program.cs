using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    class Program
    {
        const string SEPARATOR = "\n-----------------------------------------------------------------\n";
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
        static void StartLab_1(int testNrow = 100, int testNcolumn = 100)
        {
            var test = new Magazine();
            /*
             * 1) Создать один объект типа Magazine, преобразовать данные в текстовый
             * вид с помощью метода ToShortString() и вывести данные.
             */
            Console.WriteLine(test.ToShortString());
            Console.WriteLine(SEPARATOR);
            /*
             * 2) Вывести значения индексатора для значений индекса Frequency.Weekly,
             * Frequency.Monthly и Frequency.Yearly.
             */
            Console.WriteLine(test[EnumFrequency.Weekly]);
            Console.WriteLine(test[EnumFrequency.Monthly]);
            Console.WriteLine(test[EnumFrequency.Yearly]);
            Console.WriteLine(SEPARATOR);

            /*
             * 3) Присвоить значения всем определенным в типе Magazine свойствам,
             * преобразовать данные в текстовый вид с помощью метода ToString() и
             * вывести данные.
             */
            var articles = new Article[] { new Article(new Person(), "Тестовый журнал", 5) };
            var test2 = new Magazine("Тестовый журнал", EnumFrequency.Weekly, new DateTime(), 200, articles);
            Console.WriteLine(test2);
            Console.WriteLine(SEPARATOR);

            /*
             * 4) C помощью метода AddArticles( params Article*+ ) добавить элементы в
             * список статей и вывести данные объекта Magazine, используя метод
             * ToString().
             */
            test2.AddArticles(new Article(), new Article());
            Console.WriteLine(test2);
            Console.WriteLine(SEPARATOR);

            /*
             * 5) Сравнить время выполнения операций с элементами одномерного,
             * двумерного прямоугольного и двумерного ступенчатого массивов с
             * одинаковым числом элементов типа Article.
             */
            TestArraysRunTime(test2, testNrow, testNcolumn);
        }
        static void Main(string[] args)
        {
            StartLab_1(10000, 10000);
            Console.ReadLine();
        }
    }
}
