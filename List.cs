using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12Var4
{
    public class List<T>
    {

        public class Point<T>
        {

            public Point<T> left;
            public Point<T> right;
            public Organization data;
            public Point<T> next;
            public Point()
            {
                data = default;
                next = null;

            }
            public Point(Organization d)
            {
                data = d;
                next = null;
            }
            public override string ToString()
            {
                return data.ToString() + " ";
            }
            static Random rnd = new Random();
            static Organization GetInfo()
            {

                Organization k = new Organization();
                Organization Org = new Organization("Организация", 235);
                Factory Fac = new Factory("Фабрика", 450, 35, "Лондон");
                Insurance_Company Ins = new Insurance_Company("Страховая компания", 600, 1990, 98);
                Library Lib = new Library("Библиотека", 500, 7, 700);
                Shipbuilding_company Ship = new Shipbuilding_company("Кораблестроительная фирма", 490, 900000, 35);
                Organization[] mas = new Organization[5] { Org, Fac, Ins, Lib, Ship };
                Organization info = mas[rnd.Next(0, mas.Length - 1)];
                return info;
            }
            static int count = 0;
            public  static List<Organization>.Point<Organization> Root;
            public static List<Organization>.Point<Organization> IdealTree1(int size, List<Organization>.Point<Organization> p)
            {
                List<Organization>.Point<Organization> r;
                int nl, nr;
                if (size == 0) { p = null; return p; }
                nl = size / 2; nr = size - nl - 1;
                Organization d = GetInfo();
                r = new List<Organization>.Point<Organization>(d);
                if (count == 0)
                {
                    Root = r;
                    count++;
                }
                r.left = IdealTree1(nl, r.left);
                r.right = IdealTree1(nr, r.right);
                return r;
            }
            public static void ShowTree(List<Organization>.Point<Organization> p, int l)
            {
                if (p != null)
                {
                    ShowTree(p.left, l + 3);
                    for (int i = 0; i < l; i++)
                        Console.Write(" ");
                    Console.WriteLine(p.data.Number_of_employees);
                    ShowTree(p.right, l + 3);
                }
            }
            int min = Int32.MaxValue;
            Organization p5 = new Organization();
            public Organization Run(Point<Organization> p)
            {
                if (p != null)
                {
                    Run(p.left);
                    if (p.data.Number_of_employees < min)
                    {
                        min = p.data.Number_of_employees;
                        p5 = p.data;
                    }
                    Run(p.right);
                }
                return p5;
            }
            static Point<Organization> MakePoint(Organization d)
            {
                Point<Organization> p = new Point<Organization>(d);
                return p;
            }
            public Point<Organization> Add(Point <Organization> root, Organization d)
            {
                Point<Organization> p = root;
                Point<Organization> r = null;
                bool ok = false;
                while (p != null && !ok)
                {
                    r = p;
                    if (d.Number_of_employees == p.data.Number_of_employees) ok = true;
                    else if (d.Number_of_employees < p.data.Number_of_employees) p = p.left;
                    else p = p.right;
                }
                if (ok) return p;
                Point<Organization> NewPoint = MakePoint(d);
                    if (d.Number_of_employees<r.data.Number_of_employees)
                r.left = NewPoint;
                else
                    r.right = NewPoint;
                return r;
            }
            //public Point<Organization> FindTree(Point<Organization> root, params Organization[] mas)
            //{
            //    Point<Organization> p = root;
            //    Point<Organization> r = null;
            //    bool ok = false;
            //    for (int i = 0; i < mas.Length; i++)
            //    {
            //        Point<Organization> NewPoint = new Point<Organization>(mas[i]);
            //        while (p != null)
            //        {
            //            r = p;
            //            if (NewPoint.data.Number_of_employees == p.data.Number_of_employees)
            //                continue;
            //            else if (NewPoint.data.Number_of_employees > p.data.Number_of_employees)
            //            {
            //                p = p.right;
            //            }
            //            else if (NewPoint.data.Number_of_employees < p.data.Number_of_employees)
            //            {
            //                p = p.left;
            //            }
            //        }
            //        if (NewPoint.data.Number_of_employees > r.data.Number_of_employees)
            //            r.right = NewPoint;
            //        else if (NewPoint.data.Number_of_employees < r.data.Number_of_employees)
            //            r.left = NewPoint;
            //    }
            //    //while (p != null && !ok)
            //    //{
            //    //    r = p;
            //    //    if (mas[i].Number_of_employees == p.data.Number_of_employees) ok = true;
            //    //    else if (mas[i].Number_of_employees < p.data.Number_of_employees) p = p.left;
            //    //    else p = p.right;
            //    //}
            //    if (ok)
            //}
        }

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
        public List(params Organization[] mas)
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
    }
}
