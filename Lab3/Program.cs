using Lab3;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("########## ЗАДАНИЕ 1 ##########");
            MagazineCollection magColle = new MagazineCollection();
            magColle.AddDefaults();
            Magazine a = new Magazine("Дом 2", new DateTime(1000, 1, 10), 99, Frequency.Monthly);
            a.AddArticles(new Article(new Person(), "Свадьба Собчак и Бузовой", 6.1));
            Magazine b = new Magazine("Геолёнок", new DateTime(1000, 2, 10), 2, Frequency.Yearly);
            b.AddArticles(new Article(new Person(), "Аннигиляционная пушка: правда или миф?", 4.4));
            Magazine c = new Magazine("Октябрёнок", new DateTime(1111, 1, 11), 10, Frequency.Monthly);
            c.AddArticles(new Article(new Person(), "Пионер - значит первый!", 1.1));
            magColle.AddMagazines(a, b, c);
            magColle.SortByCirculation();
            Console.WriteLine("===== Отсортированы по тиражу =====");
            Console.WriteLine(magColle.ToShortString());
            magColle.SortByPubDate();
            Console.WriteLine("===== Отсортированы по дате выхода =====");
            Console.WriteLine(magColle.ToShortString());
            magColle.SortByTitle();
            Console.WriteLine("===== Отсортированы по названию =====");
            Console.WriteLine(magColle.ToShortString());
            Console.WriteLine("\nМаксимальное значение среднего рейтинга статей:");
            Console.WriteLine(magColle.MaxAverRating);
            Console.WriteLine("\nЖурналы с периодичностью выхода Frequency.Monthly:");
            foreach (var obj in magColle.Monthly)
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine("\nЭлементы по значению среднего рейтинга статей:");
            foreach (var obj in magColle.RatingGroup(4))
            {
                Console.WriteLine(obj);
            }

            TestCollections testColle = new TestCollections(10000);
            Console.WriteLine("TestCollections");
            int[] test = testColle.Test(0);
            Console.WriteLine("Первый:");
            for (int i = 0; i < 4; ++i)
            {
                Console.Write(test[i].ToString() + ' ');
            }
            Console.WriteLine("\n--");
            test = testColle.Test(50000);
            Console.WriteLine("Центральный:");
            for (int i = 0; i < 4; ++i)
            {
                Console.Write(test[i].ToString() + ' ');
            }
            Console.WriteLine("\n---");
            test = testColle.Test(10000);

            Console.WriteLine("Последний:");
            for (int i = 0; i < 4; ++i)
            {
                Console.Write(test[i].ToString() + ' ');
            }
            Console.WriteLine("\n----");
            test = testColle.Test(-1);
            Console.WriteLine("Вне коллекции:");
            for (int i = 0; i < 4; ++i)
            {
                Console.Write(test[i].ToString() + ' ');
            }

            Console.WriteLine();
        }
    }

    enum Frequency { Weekly, Monthly, Yearly };


    interface IRateAndCopy
    {
        double Rating { get; }
        object DeepCopy();
    }
}
