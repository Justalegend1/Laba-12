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
        public DoubleList(params T []mas)
        {
            beg = new DoublePoint<T>(mas[0]);
            DoublePoint<T> p = beg;
            for (int i = 1; i < mas.Length; i++)
            {
               
                DoublePoint<T> temp = new DoublePoint<T>(mas[i]);
                DoublePoint<T> vr = new DoublePoint<T>(mas[i - 1]);
                p.next = temp;
                p = temp;
                p.pred = vr;
            }
        }
        public class DoublePoint<T>
        {
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

            public override string ToString()
            {
                return data.ToString() + " ";
            }
        }
            public DoublePoint<T> beg = null;
            public void PrintList()
            {
                if (beg == null)
                {
                    Console.WriteLine("Пустой список!");
                    return;

                }
                DoublePoint<T> p = beg;
                while (p != null)
                {
                    Console.WriteLine(p);
                    p = p.next;
                }
                Console.WriteLine();
            }
        
    }
}
