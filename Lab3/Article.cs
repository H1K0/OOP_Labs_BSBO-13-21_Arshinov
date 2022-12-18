using System;

namespace lab
{
    class Article : IRateAndCopy
    {
        public Person Person { get; set; }
        public string Title { get; set; }
        public double Rating { get; set; }

        public Article(Person pers, string title, double rating)
        {
            this.Person = pers;
            this.Title = title;
            this.Rating = rating;
        }

        public Article()
        {
            this.Person = new Person();
            this.Title = "Default Title";
            this.Rating = 0.0d;
        }

        public override string ToString()
        {
            return $"Автор {Person}, Название статьи: {Title}, Рейтинг статьи: {Rating}";
        }


        public virtual object DeepCopy()
        {
            Article copy_article = new Article(Person, Title, Rating);
            return copy_article;
        }

    }
}