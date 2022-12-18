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
            // Исследуем время, необходимое для выполнения операций
            // с элементами массивов
            Console.Write("Введите число строк двухмерного массива: ");
            int height = int.Parse(Console.ReadLine());
            Console.Write("Введите количество столбцов двумерного массива: ");
            int width = int.Parse(Console.ReadLine());
            int count = height * width;
            var arr1 = new Article[count];
            for (int i = 0; i < count; i++)
            {
                arr1[i] = new Article();
            }
            int start = Environment.TickCount;
            for (int i = 0; i < count; i++)
            {
                arr1[i].Title = "SomeTitle";
            }
            int end = Environment.TickCount;
            Console.WriteLine($"Время операций над одномерным массивом {height}x{width}: {end - start}");

            var arr2 = new Article[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    arr2[i, j] = new Article();
                }
            }
            start = Environment.TickCount;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    arr2[i, j].Title = "SomeTitle";
                }
            }
            end = Environment.TickCount;
            Console.WriteLine($"Время операций над двумерным массивом {height}x{width}: {end - start}");

            // Количество элементов двумерного ступенчатого массива определяется
            // как сумма арифметической прогрессии с шагом 1.
            // Находим последнее значение прогрессии:
            // x*(x+1)/2 = count
            // x^2 + x - 2*count = 0
            // x = ceil((-1 + sqrt(1 + 8*count))/2)
            int x = (int)Math.Ceiling((-1 + Math.Sqrt(1 + 8 * count)) / 2);
            var arr3 = new Article[x][];
            int k = 1;
            for (int i = 0; i < x && k < count; i++)
            {
                arr3[i] = new Article[i + 1];
                for (int j = 0; j <= i && k < count; j++)
                {
                    arr3[i][j] = new Article();
                    k++;
                }
            }
            k = 1;
            start = Environment.TickCount;
            for (int i = 0; i < x && k < count; i++)
            {
                for (int j = 0; j <= i && k < count; j++)
                {
                    arr3[i][j].Title = "SomeTitle";
                    k++;
                }
            }
            end = Environment.TickCount;
            Console.WriteLine($"Время операций над двумерным ступенчатым массивом {height}x{width}: {end - start}");

            //Console.ReadKey();

            Console.WriteLine("\n\n######## ЗАДАНИЕ 2 ##########");
            Edition v1 = new Edition();
            Edition v2 = new Edition();
            Console.WriteLine(Object.ReferenceEquals(v1, v2));
            Console.WriteLine(v1 == v2);
            Console.WriteLine($"Хеш-код первого объекта v1 {v1.GetHashCode()}");
            Console.WriteLine($"Хеш-код первого объекта v2 {v2.GetHashCode()}");

            try
            {
                v1.Circulation = -1;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            Magazine mag1 = new Magazine();
            mag1.AddEditors(new Person[] { new Person("Василий", "Гурьянов", new DateTime(2003, 10, 3)), new Person("Валерий", "Аносов", new DateTime(1984, 5, 4)), new Person("Вася", "Пупкин", new DateTime(2000, 1, 1)) });
            mag1.AddArticles(new Article[] { new Article(new Person("Василий", "Гурьянов", new DateTime(2003, 10, 3)), "БугуртТред1", 4.5), new Article(new Person("Валерий", "Аносов", new DateTime(1984, 5, 4)), "О пользе алгебры", 3.1) });
            for (int i = 0; i < mag1.Articles.Count; i++)
            {
                Console.WriteLine(mag1.Articles[i]);
            }
            for (int i = 0; i < mag1.Editors.Count; i++)
            {
                Console.WriteLine(mag1.Editors[i]);
            }

            Console.WriteLine(mag1.Edition);

            Magazine mag2 = mag1.DeepCopy();
            mag1.Circulation = 10;
            mag1.AddArticles(new Article[] { new Article(new Person("Гурилий", "Васьянов", new DateTime(2003, 3, 10)), "ТредБугурт", 5.4), new Article(new Person("Алерий", "Ваносов", new DateTime(1984, 4, 5)), "О пользе геометрии", 1.3) });
            Console.WriteLine("========== ЖУРНАЛ 1 ==========");
            Console.WriteLine(mag1);
            Console.WriteLine("========== ЖУРНАЛ 2 ==========");
            Console.WriteLine(mag2);
            Console.WriteLine("==============================");

            ArrayList temp = mag1.Articles;
            for (int i = 0; i < mag1.Articles.Count; i++)
            {
                foreach (double a in mag1.ByRating(2.0))
                {
                    if (a == ((Article)temp[i]).Rating)
                    {
                        System.Console.WriteLine(((Article)temp[i]));
                    }
                }
            }
            Console.WriteLine("==============================");
            for (int i = 0; i < mag1.Articles.Count; i++)
            {
                foreach (string a in mag1.ByNameSubstring("угу"))
                {
                    if (a == ((Article)temp[i]).Title)
                    {
                        Console.WriteLine(((Article)temp[i]));
                    }
                }
            }


            Console.WriteLine("\n========== Enumerator 1 ==========");
            foreach (var a in mag1)
            {
                Console.WriteLine(a);
            }

            Console.WriteLine("========== Enumerator 2 ==========");
            foreach (Article a in mag1.ByArticle())
            {
                Console.WriteLine(a);
            }

            Console.WriteLine("========== Enumerator 3 ==========");
            foreach (Person a in mag1.ByPerson())
            {
                Console.WriteLine(a);
            }

        }
    }

    enum Frequency { Weekly, Monthly, Yearly };


    interface IRateAndCopy
    {
        double Rating { get; }
        object DeepCopy();
    }
}
