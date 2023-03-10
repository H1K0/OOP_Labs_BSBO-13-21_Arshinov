using System;

namespace lab
{
    class Edition
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

    }

    class EditionException : ArgumentException
    {
        public EditionException(string message)
        : base(message) { }
    }
}