using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12Var4
{
    public class DoubleListConnection<T>
    {
        public DoublePointConnection<T> beg = null;
        public class DoublePointConnection<T>
        {
            public T data;
            public DoublePointConnection<T> next;
            public DoublePointConnection<T> pred;
            public DoublePointConnection()
            {
                data = default;
                next = null;
                pred = null;
            }
            public DoublePointConnection(T d)
            {
                next = null;
                data = d;
                pred = null;
            }

            public override string ToString()
            {
                return data.ToString() + " ";
            }
        }
        public DoubleListConnection()
        { }
        public DoubleListConnection(params T[] mas)
        {
            DoublePointConnection<T> r;
            beg = new DoublePointConnection<T>(mas[0]);
            DoublePointConnection<T> p = beg;
            for (int i = 1; i < mas.Length; i++)
            {
                DoublePointConnection<T> temp = new DoublePointConnection<T>(mas[i]);
                DoublePointConnection<T> vr = new DoublePointConnection<T>(mas[i - 1]);
                p.next = temp;
                p = temp;
                p.pred = vr;
                if (i == mas.Length - 1)
                {
                    r = p;
                    p.next = beg;
                    p = beg;
                    p.pred = r;
                }
            }
        }
        public int Count
        {
            get
            {
                DoublePointConnection<T> k = beg;
                int count = 1;
                while (k != beg)
                {
                    count++;
                    k = k.next;
                }
                return count;
            }
        }
        public void Delete(int nom)
        {
            DoublePointConnection<T> dp1;
            DoublePointConnection<T> dp = beg;
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
        public void Add(int nom, params T[] mas)
        {
            DoublePointConnection<T> p1 = beg;
            DoublePointConnection<T> temp1 = new DoublePointConnection<T>(mas[rnd.Next(0, mas.Length - 1)]);
            DoublePointConnection<T> vr1;
            DoublePointConnection<T> vr2;
            DoublePointConnection<T> p2 = beg;
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
    }
}
