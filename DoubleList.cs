using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12Var4
{
    public class DoubleList<T>
    {

        public DoubleList()
        { }
        public DoubleList(params Organization[]mas)
        {
            beg = new DoublePoint<Organization>(mas[0]);
            DoublePoint<Organization> p = beg;
            for (int i = 1; i < mas.Length; i++)
            {
               
                DoublePoint<Organization> temp = new DoublePoint<Organization>(mas[i]);
                DoublePoint<Organization> vr = new DoublePoint<Organization>(mas[i - 1]);
                p.next = temp;
                p = temp;
                p.pred = vr;
            }
        }
        public class DoublePoint<T>
        {
            public DoublePoint<T> Clone()
            {
                return new DoublePoint<T> { data = this.data, next = this.next, pred = this.pred };
            }
            public object ClonePoverx()
            {
                return this.MemberwiseClone();
            }
            public T data;
            public DoublePoint<T> next;
            public DoublePoint<T> pred;
            public DoublePoint()
            {
                data = default;
                next = null;
                pred = null;
            }
            public DoublePoint(T d)
            {
                next = null;
                data = d;
                pred = null;
            }
            public DoublePoint(DoublePoint<T> dp)
            {
                this.data = dp.data;
                this.next = dp.next;
                this.pred = dp.pred;
            }

            public override string ToString()
            {
                return data.ToString() + " ";
            }
        }
            public DoublePoint<Organization> beg = null;
            public void PrintList()
            {
                if (beg == null)
                {
                    Console.WriteLine("Пустой список!");
                    return;

                }
                DoublePoint<Organization> p = beg;
                while (p != null)
                {
                    Console.WriteLine(p);
                    p = p.next;
                }
                Console.WriteLine();
            }
        public void Delete(int nom)
        {
            DoublePoint<Organization> dp1;
            DoublePoint<Organization> dp = beg;
            for (int t = 0; t < nom; t++)
            {
                dp = dp.next;
            }
            dp.next = dp.next.next;
            dp1 = dp;
            dp = dp.next.next;
            dp.pred = dp1;
        }
        static Random rnd = new Random();
        public void Add(int nom, params Organization[]mas)
        {
            DoublePoint<Organization> p1 = beg;
            DoublePoint<Organization> temp1 = new DoublePoint<Organization>(mas[rnd.Next(0,mas.Length-1)]);
            DoublePoint<Organization> vr1;
            DoublePoint<Organization> vr2;
            DoublePoint<Organization> p2 = beg;
            for (int i = 1; i < nom; i++)
                p2 = p2.next;
            vr2 = p2;
            for (int i = 1; i < nom - 1; i++)
                p1 = p1.next;
            vr1 = p1;
            p1.next = temp1;
            p1 = p1.next;
            p1.pred = vr1;
            p1.next = vr2;
        }
        public void DeleteCollection(T beg)//нужно передать корень коллекции
        {
            this.beg = null;
        }
        public void FindInColl(T beg1, int employee)
        {
            DoublePoint<Organization> p = beg;
            while (p != null)
            {
                if (p.data.Number_of_employees == employee)
                    Console.WriteLine(p.ToString());
                p = p.next;
            }
        }
    }
}
