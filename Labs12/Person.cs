using System;

namespace lab
{
    class Person
    {
        // Имя
        private string name;
        // Фамилия
        private string surname;
        // Дата рождения
        private DateTime birthday;

        public Person()
        {
            this.name = "Иван";
            this.surname = "Иванов";
            this.birthday = new DateTime(1970, 1, 1);
        }

        public Person(string name, string surname, DateTime birthday)
        {
            this.name = name;
            this.surname = surname;
            this.birthday = birthday;
        }

        public string Name
        {
            get => name;
            set => this.name = value;
        }

        public string Surname
        {
            get => surname;
            set => this.surname = value;
        }

        public DateTime Birthday
        {
            get => birthday;
            set => this.birthday = value;
        }


        public int Year
        {
            get => (int)birthday.Year;
            set => this.birthday = new DateTime(value, birthday.Month, birthday.Day);
        }

        public override string ToString()
        {
            return $"Имя: {name}, Фамилия: {surname}, Дата рождения: {birthday}";
        }

        public virtual string ToShortString()
        {
            return $"Имя: {name}, Фамилия: {surname}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj is not Person)
            {
                return false;
            }
            return (Name == ((Person)obj).Name && Surname == ((Person)obj).Surname && Birthday == ((Person)obj).Birthday);
        }

        public static bool operator ==(Person pers1, Person pers2)
        {
            return pers1.Equals(pers2);
        }

        public static bool operator !=(Person pers1, Person pers2)
        {
            return !pers1.Equals(pers2);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Surname.GetHashCode() ^ Birthday.GetHashCode();
        }

        public virtual Person DeepCopy()
        {
            Person copy_person = new Person(this.name, this.surname, this.birthday);
            return copy_person;
        }
    }
}