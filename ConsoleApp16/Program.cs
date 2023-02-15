using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp16
{
    class Book : ICloneable
    {
        public string Name { get; set; }

        public string Autor { get; set; }

        public Book(string name, string autor)
        {
            this.Name = name;
            this.Autor = autor;
        }

        public Book() : this("Война и мир", "Лев Толстой") { }

        public void Show()
        {
            Console.WriteLine("\n{0}   {1}", Name, Autor);
        }

        public void Input()
        {
            Console.WriteLine("\nВведите название книги: ");
            this.Name = Console.ReadLine();
            Console.WriteLine("\nВведите имя автора: ");
            this.Autor = Console.ReadLine();
        }
        public class SortByName : IComparer
        {
            int IComparer.Compare(object obj1, object obj2)
            {
                if (obj1 is Book && obj2 is Book)
                    return (obj1 as Book).Name.CompareTo((obj2 as Book).Name);

                throw new NotImplementedException();
            }
        }
        public class SortByAutor : IComparer
        {
            int IComparer.Compare(object obj1, object obj2)
            {
                if (obj1 is Book && obj2 is Book)
                    return (obj1 as Book).Autor.CompareTo((obj2 as Book).Autor);

                throw new NotImplementedException();
            }
        }
        public object Clone()
        {
            return new Book(Name, Autor);
        }
    }

    class Library : IEnumerable, IEnumerator
    {
        Book[] ar;
        int curpos = -1;
        public Library(int len)
        {
            ar = new Book[len];
            for (int i = 0; i < len; i++)
            {
                ar[i] = new Book();
            }
        }

        public Library() : this(1) { }

        public Library(Book[] clubs)
        {
            ar = new Book[clubs.Length];
            for (int i = 0; i < clubs.Length; i++)
            {
                ar[i] = new Book(clubs[i].Name, clubs[i].Autor);
            }
        }

        public void InputClub()
        {
            for (int i = 0; i < ar.Length; i++)
                ar[i].Input();
        }

        public void ShowClubs()
        {
            for (int i = 0; i < ar.Length; i++)
                ar[i].Show();
        }


        public IEnumerator GetEnumerator()
        {
            
            return this;
        }

        #region enumerator

        public void Reset()
        {
           
            curpos = -1;
        }
        public object Current 
        {
            get
            {
               
                return ar[curpos];
            }
        }

        public bool MoveNext()
        {
           
            if (curpos < ar.Length - 1)
            {
                curpos++;
                return true;
            }
            else
            {
                this.Reset();
                return false;
            }

        }
        #endregion enumerator
    }

    class MainClass
    {
        public static void Main()
        {
            Book[] c = new Book[6];
            c[0] = new Book("Война и мир", "Лев Толстой");
            c[1] = new Book("1984", "Джордж Оруэлл");
            c[2] = new Book("Улисс", "Джеймс Джойс");
            c[3] = new Book("Лолита", "Влади­мир Набоков");
            c[4] = new Book("Шум и ярость", "Уильям Фолкнер");
            c[5] = new Book("Неви­димка", "Ральф Эллисон");
            foreach (Book temp in c)
            {
                temp.Show();
            }

            Library lg = new Library(c);

            foreach (Book temp in lg)
            {
                temp.Show();
            }

            foreach (Book temp in lg)
            {
                temp.Show();
            }

            Array.Sort(c, new Book.SortByName());
            Console.WriteLine("\nМассив, упорядоченный по названию:");
            foreach (Book temp in c)
            {
                temp.Show();
            }
                
            Array.Sort(c, new Book.SortByAutor());
            Console.WriteLine("\nМассив, упорядоченный по автору:");
            foreach (Book temp in c)
            {
                temp.Show();
            }

            Book c1 = new Book();
            foreach (Book temp in c)
            {
                temp.Show();
            }
            Book c2 = c1; 
            c2.Name = "Улисс";
            c2.Autor = "Джеймс Джойс";

            foreach (Book temp in c)
            {
                temp.Show();
            }

            Book c3 = c.Clone() as Book; 
            c3.Name = "1984";
            c3.Autor = "Джордж Оруэлл";

            foreach (Book temp in c)
            {
                temp.Show();
            }
        }
    }
}
