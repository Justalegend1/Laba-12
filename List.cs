using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12Var4
{
    public class List<T>
    {

        public Point<Organization> beg = null;
        public int Length
        {
            get
            {
                if (beg == null) return 0;
                Point<Organization> p = beg; ;
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
            beg = new Point<Organization>();
            Point<Organization> p = beg;
            for (int i = 1; i < size; i++)
            {
                Point<Organization> temp = new Point<Organization>();
                p.next = temp;
                p = temp;
            }

        }
        public Point<Organization> last;
        public List(params Organization[] mas)
        {
            beg = new Point<Organization>(mas[0]);
            Point<Organization> p = beg;
            for (int i = 1; i < mas.Length; i++)
            {
                Point<Organization> temp = new Point<Organization>(mas[i]);
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
            Point<Organization> p = beg;
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
            Point<Organization> temp = new Point<Organization>();
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
            Point<Organization> p = beg;
            for (int i = 1; i < nom; i++)
                p = p.next;
            Point<Organization> t = p.next;
            p.next = t.next;
        }
        public void Delete(int nom)
        {
            Point<Organization> ls = beg;
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
                Point<Organization> lst = beg;
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
                Point<Organization> k = beg;
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
        public void Add(int nom, params Organization[]mas)
        {
            Point<Organization> p1 = beg;
            Point<Organization> point = beg;
            Point<Organization> d = new Point<Organization>(mas[rnd.Next(0, mas.Length - 1)]);
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
        public void DeleteCollection(T beg)//нужно передать корень коллекции
        {
            this.beg = null;
        }
        public void FindInColl(T beg1, int employee)
        {
            Point<Organization> p = beg;
            while (p != null)
            {
                if (p.data.Number_of_employees == employee)
                    Console.WriteLine(p.ToString());
                p = p.next;
            }
        }
    }
}
