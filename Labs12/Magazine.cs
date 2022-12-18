using lab;
using System;
using System.Collections;
using System.Collections.Generic;

namespace lab
{
    class Magazine : Edition, IRateAndCopy
    {
        // Частота издания
        private Frequency frequency;
        // Редакторы
        private ArrayList editors = new ArrayList();
        // Статьи
        private ArrayList articles = new ArrayList();

        public Magazine() : base()
        {
            this.frequency = Frequency.Yearly;
        }

        public Magazine(string title, DateTime pubdate, int circulation, Frequency period, ArrayList articles, ArrayList editors)
            : base(title, pubdate, circulation)
        {
            this.frequency = period;
            this.articles = articles;
            this.editors = editors;
        }

        public IEnumerable<double> ByRating(double rating)
        {
            foreach (Article a in articles)
            {
                if (a.Rating > rating)
                    yield return a.Rating;
            }
        }

        public IEnumerable<string> ByNameSubstring(string substr)
        {
            foreach (Article p in articles)
            {
                if (p.Title.IndexOf(substr) > -1)
                    yield return p.Title;
            }
        }

        public IEnumerable<Article> ByArticle()
        {
            foreach (Article a in articles)
            {
                if ((editors.Contains(a.Person)))
                {
                    yield return a;
                }
            }
        }

        public IEnumerable<Person> ByPerson()
        {
            List<Person> temp = new List<Person>();
            foreach (Article a in articles)
            {
                temp.Add(a.Person);
            }
            foreach (Person a in editors)
            {
                if (!temp.Contains(a))
                    yield return a;
            }
        }

        public double Rating
        {
            get
            {
                double sum = 0;
                if (articles.Count == 0)
                {
                    return 0;
                }
                else
                {
                    foreach (Article el in articles)
                    {
                        sum += el.Rating;
                    }
                    return sum / articles.Count;
                }
            }
        }

        public Edition Edition
        {
            get
            {
                return new Edition(base.Title, base.PubDate, base.Circulation);
            }
            set
            {
                Edition temp = (Edition)value;
                base.Title = temp.Title;
                base.PubDate = temp.PubDate;
                base.Circulation = temp.Circulation;
            }
        }

        public override Magazine DeepCopy()
        {
            List<Article> temp_articles = new List<Article>();
            List<Person> temp_editors = new List<Person>();
            foreach (Article a in (Article[])articles.ToArray(typeof(Article)))
            {
                temp_articles.Add((Article)a.DeepCopy());
            }
            foreach (Person a in (Person[])editors.ToArray(typeof(Person)))
            {
                temp_editors.Add((Person)a.DeepCopy());
            }

            Magazine copy_magazine = new Magazine(base.title, base.pubdate, base.circulation, frequency, new ArrayList(temp_articles), new ArrayList(temp_editors));
            return copy_magazine;
        }

        public ArrayList Articles { get { return articles; } set { this.articles = value; } }
        public ArrayList Editors { get { return editors; } set { this.editors = value; } }

        public void AddArticles(params Article[] articles)
        {
            this.articles.AddRange(articles);
        }

        public void AddEditors(params Person[] editors)
        {
            this.editors.AddRange(editors);
        }

        public override string ToString()
        {
            string string_article = "";
            for (int i = 0; i < articles.Count; i++)
            {
                string_article += articles[i].ToString();
            }
            string string_editors = "";
            for (int i = 0; i < editors.Count; i++)
            {
                string_editors += editors[i].ToString();
            }
            return $"Название: {base.title}, Дата публикации: {base.pubdate}, Тираж: {base.circulation}, Период публикации {frequency}, Список статей: {string_article}, Список редакторов: {string_editors}";
        }

        public virtual string ToShortString()
        {
            return $"Название: {base.title}, Дата публикации: {base.pubdate}, Тираж: {base.circulation}, Период публикации {frequency}, {Rating}";
        }

        public IEnumerator GetEnumerator() => new MagazineEnumerator(this);

    }
}