using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12Var4
{
    public class List<T>
    {

        public Point<T> beg = null;
        public int Length
        {
            get
            {
                if (beg == null) return 0;
                Point<T> p = beg; ;
                int len = 0;
                while (p != null)
                {
                    p = p.next;
                    len++;
                }
                return len;
            }

        }
        public List()
        {

        }
        public List(int size)
        {
            beg = new Point<T>();
            Point<T> p = beg;
            for (int i = 1; i < size; i++)
            {
                Point<T> temp = new Point<T>();
                p.next = temp;
                p = temp;
            }

        }
        public Point<T> last;
        public List(params T[] mas)
        {
            beg = new Point<T>(mas[0]);
            Point<T> p = beg;
            for (int i = 1; i < mas.Length; i++)
            {
                Point<T> temp = new Point<T>(mas[i]);
                p.next = temp;
                p = temp;
                if (p.next == null)
                    last = p;
            }
        }
        public void PrintList()
        {
            if (beg == null)
            {
                Console.WriteLine("Пустой список!");
                return;

            }
            Point<T> p = beg;
            while (p != null)
            {
                Console.WriteLine(p.data);
                p = p.next;
            }
            Console.WriteLine();
        }
        //public void ShowTree(Point<Organization> p, int l)
        //{
        //    if (p != null)
        //    {
        //        ShowTree(p.left, l + 3);
        //        for (int i = 0; i < l; i++)
        //            Console.Write(" ");
        //        Console.WriteLine(p.data);
        //        ShowTree(p.right, l + 3);
        //    }
        //}

        public void AddPointToBeg(T d)
        {
            Point<T> temp = new Point<T>();
            if (beg == null)
            {
                beg = temp;
                return;
            }
            temp.next = beg;
            beg = temp;
        }
        public void RemovePoint(int nom)
        {
            if (beg == null)
            {
                return;
            }
            if (nom > Length)
            {
                Console.WriteLine("Ошибка! Введенный номер выходит за границы списка");
                return;
            }
            if (beg.next == null)
            {
                beg = null;
                return;
            }
            if (nom == 1)
            {
                beg = beg.next;
                return;
            }
            if (nom < 0)
            {
                Console.WriteLine("Индекс введенного элемента не может быть меньше нуля");
                return;
            }
            Point<T> p = beg;
            for (int i = 1; i < nom; i++)
                p = p.next;
            Point<T> t = p.next;
            p.next = t.next;
        }
        public void Delete(int nom)
        {
            Point<T> ls = beg;
            if (nom == Count)
            {
                for (int j = 0; j < Count - 1; j++)
                    ls = ls.next;
                ls.next = null;
            }
            else if (nom == 1)
            {
                beg = beg.next;
            }
            else
            {
                Point<T> lst = beg;
                for (int t = 0; t < nom; t++)
                {
                    lst = lst.next;
                }
                lst.next = lst.next.next;
            }

        }
        public int Count
        {
            get
            {
                Point<T> k = beg;
                int count = 1;
                while (k != beg)
                {
                    count++;
                    k = k.next;
                }
                return count;
            }
        }
        //public class FindTree
        //{
        //    public class FindPoint<T>
        //    {
        //        T data;
        //        FindPoint<T> left;
        //        FindPoint<T> right;
        //        public FindPoint()
        //        {
        //            data = default;
        //            left = null;
        //            right = null;
        //        }
        //        FindPoint(Organization d)
        //        {
        //            left = null;
        //            right = null;
        //            data = d;
        //        }
        //    }
        //    public static FindTree1()
        //    {

        //    }
        //}
        static Random rnd = new Random();
        public void Add(int nom, params T[]mas)
        {
            Point<T> p1 = beg;
            Point<T> point = beg;
            Point<T> d = new Point<T>(mas[rnd.Next(0, mas.Length - 1)]);
            if (nom == 1)
            {
                d.next = beg;
                beg = d;
            }
            else
                for (int i = 1; i < nom-1; i++)
                {
                    point = point.next;
                }
            for (int l = 1; l < nom; l++)
                p1 = p1.next;
            point.next = d;
            point = point.next;
            point.next = p1;
        }
    }
}
