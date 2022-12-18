using System;
using System.Xml.Linq;

namespace lab
{
    class Edition : IComparable, IComparer<Edition>
    {
        // Название издания
        protected string title;
        // Дата выхода издания
        protected DateTime pubdate;
        // Тираж издания
        protected int circulation;

        public Edition()
        {
            this.title = "Default Title";
            this.pubdate = new DateTime(0001, 1, 1);
            this.circulation = 0;
        }

        public Edition(string title, DateTime date, int circulation)
        {
            this.title = title;
            this.pubdate = date;
            this.circulation = circulation;
        }

        public string Title { get { return title; } set { this.title = value; } }
        public DateTime PubDate { get { return pubdate; } set { this.pubdate = value; } }
        public int Circulation
        {
            get { return circulation; }
            set
            {
                if (value < 0)
                {
                    throw new EditionException("Тираж не может быть отрицательным числом");
                }
                else
                {
                    this.circulation = value;
                }
            }

        }

        public virtual Object DeepCopy()
        {
            Edition copy_edition = new Edition(title, pubdate, circulation);
            return copy_edition;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj is not Edition)
            {
                return false;
            }
            return (Title == ((Edition)obj).Title && PubDate == ((Edition)obj).PubDate && Circulation == ((Edition)obj).Circulation);
        }

        public override int GetHashCode()
        {
            return Title.GetHashCode() ^ PubDate.GetHashCode() ^ Circulation.GetHashCode();
        }

        public static bool operator ==(Edition ed1, Edition ed2)
        {
            return ed1.Equals(ed2);
        }

        public static bool operator !=(Edition ed1, Edition ed2)
        {
            return !ed1.Equals(ed2);
        }

        public override string ToString()
        {
            return ($"Название: {title} Дата публикации: {pubdate} Тираж: {circulation}");
        }

        public int CompareTo(object? b)
        {
            Edition second = b as Edition;
            if (second == null) return -1;
            int result = 0;
            int len = Math.Min(title.Length, second.title.Length);
            for (int i = 0; i < len - 1; i++)
            {
                if (title[i] < second.title[i])
                {
                    result = 1;
                    break;
                }
                if (title[i] > second.title[i])
                {
                    result = -1;
                    break;
                }
            }

            return 0;//title.CompareTo(second.title);
        }
        public int Compare(Edition a, Edition b)
        {
            if (a.pubdate < b.pubdate)
            {
                return -1;
            }
            else if (a.pubdate > b.pubdate)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public IComparer<Edition> SComparer = new CompareByCirculation();
        public class CompareByCirculation : IComparer<Edition>
        {
            public int Compare(Edition a, Edition b)
            {
                if (a.circulation < b.circulation)
                {
                    return -1;
                }
                else if (a.circulation > b.circulation)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }

    class EditionException : ArgumentException
    {
        public EditionException(string message)
        : base(message) { }
    }
}