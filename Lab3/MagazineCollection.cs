using lab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class MagazineCollection
    {
        List<Magazine> magazines = new List<Magazine>();
        public void AddDefaults()
        {
            for (int i = 0; i < 5; i++)
            {
                magazines.Add(new Magazine());
            }
        }
        public void AddMagazines(params Magazine[] magazines)
        {
            this.magazines = magazines.Concat(magazines).ToList();
        }
        public double MaxAverRating
        {
            get
            {
                double max = 0;
                max = magazines.Max(magazines => magazines.Rating);
                return max;
            }
        }
        public IEnumerable<Magazine> Monthly
        {
            get
            {
                List<Magazine> month = new List<Magazine>();
                month = magazines.Where(magazines => magazines.Frequency == Frequency.Monthly).ToList();
                return month;
            }
        }
        public List<Magazine> RatingGroup(double value)
        {
            return this.magazines.Where(m => m.Rating > value).ToList();
        }
        public void SortByTitle()
        {
            magazines.Sort();
        }
        public void SortByPubDate()
        {
            Magazine mg = new Magazine();
            magazines.Sort(mg);
            //magazines.OrderBy(mg);
        }
        public void SortByCirculation()
        {
            Edition ed = new Edition();
            magazines.Sort(ed.SComparer);
        }
        public override string ToString()
        {
            foreach (var item in magazines)
            {
                return item.ToString() + "";
            }
            return "\n\n";
        }
        public virtual string ToShortString()
        {
            foreach (var item in magazines)
            {
                Console.WriteLine(item.ToShortString());
                Console.WriteLine("");
            }
            return "\n\n";
        }
    }
}
