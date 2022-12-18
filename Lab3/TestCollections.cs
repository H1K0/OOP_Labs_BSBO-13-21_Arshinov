using lab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class TestCollections
    {
        private List<Edition> editions;
        private List<string> titles;
        private Dictionary<Edition, Magazine> dict1;
        private Dictionary<string, Magazine> dict2;
        Random random;
        IEnumerable<Magazine> GetMagazines(int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return new Magazine(random.Next(0xfffffff).ToString(), new DateTime(random.Next(0xfffffff)), random.Next(0xfffffff), Frequency.Weekly);
            }
        }

        public TestCollections(int count)
        {
            random = new Random(Environment.TickCount);
            editions = GetMagazines(count).Select(m => m.Edition).ToList();
            titles = GetMagazines(count).Select(m => m.Title).ToList();
            while (true)
                try
                {
                    dict1 = GetMagazines(count).ToDictionary(key => key.Edition);
                    break;
                }
                catch { }
            while (true)
                try
                {
                    dict2 = GetMagazines(count).ToDictionary(key => key.Title);
                    break;
                }
                catch { }
        }

        public int[] Test(int index)
        {
            int[] list = new int[4];
            Edition tmp;
            string str;
            if (index < 0 || index >= editions.Count)
            {
                tmp = new Edition("Абоба", new DateTime(1200, 2, 2), 123456);
                str = "Абоба";
            }
            else
            {
                str = titles[index];
                tmp = editions[index];
            }
            Console.WriteLine(Environment.TickCount);
            int start = Environment.TickCount;
            editions.Find(e => e == tmp);
            Console.WriteLine(Environment.TickCount);
            int fin = Environment.TickCount;
            list[0] = fin - start;

            start = Environment.TickCount;
            titles.Find(s => s == str);
            list[1] = Environment.TickCount - start;

            if (!(index < 0 || index >= editions.Count))
                tmp = dict1.Keys.ToList()[index];

            start = Environment.TickCount;
            dict1.ContainsKey(tmp);
            list[2] = Environment.TickCount - start;

            if (!(index < 0 || index >= editions.Count))
                str = dict2.Keys.ToList()[index];

            start = Environment.TickCount;
            dict2.ContainsKey(str);
            list[3] = Environment.TickCount - start;

            Console.WriteLine(Environment.TickCount);
            return list;
        }
    }
}
