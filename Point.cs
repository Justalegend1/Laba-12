using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12Var4
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
            public static Point<Organization> Root;
            public static Point<Organization> IdealTree1(int size, Point<Organization> p)
            {
                Point<Organization> r;
                int nl, nr;
                if (size == 0) { p = null; return p; }
                nl = size / 2; nr = size - nl - 1;
                Organization d = GetInfo();
                r = new Point<Organization>(d);
                if (count == 0)
                {
                    Root = r;
                    count++;
                }
                r.left = IdealTree1(nl, r.left);
                r.right = IdealTree1(nr, r.right);
                return r;
            }
            public static void ShowTree(Point<Organization> p, int l)
            {
                if (p != null)
                {
                    ShowTree(p.left, l + 7);
                    for (int i = 0; i < l; i++)
                        Console.Write(" ");
                    Console.WriteLine(p.data.Number_of_employees);
                    ShowTree(p.right, l + 7);
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
           static public Point<Organization> Add(Point<Organization> root, Organization d)
            {
            if (root == null) return new Point<Organization>(d);
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
                if (d.Number_of_employees < r.data.Number_of_employees)
                    r.left = NewPoint;
                else
                    r.right = NewPoint;
                return NewPoint;
            }
        public static void recAdd(Point<Organization> root, Point<Organization> NewPoint)
        {
            if (NewPoint.left != null)
            {
                Point<T>.Add(root, NewPoint.left.data);
                recAdd(root, NewPoint.left);
            }
            if (NewPoint.right != null)
            {
                Point<T>.Add(root, NewPoint.right.data);
                recAdd(root, NewPoint.right);
            }
        }
        public Point<T> Clone()
        {
            return new Point<T> { data = this.data, next = this.next };
        }
        public object ClonePoverx()
        {
            return this.MemberwiseClone();
        }
    }
}
