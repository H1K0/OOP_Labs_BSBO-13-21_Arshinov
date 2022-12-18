using lab;
using System;
using System.Collections;


namespace lab
{
    class MagazineEnumerator : IEnumerator
    {
        Magazine magazine;
        int position = -1;

        List<Person> temp = new List<Person>();
        List<Article> temp1 = new List<Article>();

        public MagazineEnumerator(Magazine magazine)
        {
            this.magazine = magazine;
            this.temp = new List<Person>(magazine.Editors);
            this.temp1 = new List<Article>(magazine.Articles);
        }

        public object Current
        {
            get
            {
                return magazine.Articles[position];
            }
        }
        public bool MoveNext()
        {
            while (++position < magazine.Articles.Count && IsEditor(temp, temp1[position])) ;
            return position < magazine.Articles.Count;
        }
        public void Reset()
        {
            position = -1;
        }

        private bool IsEditor(List<Person> editors, Article article)
        {
            return (editors.Contains(article.Person));

        }
    }
}