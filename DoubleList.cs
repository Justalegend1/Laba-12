using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12Var4
{
    public class DoubleList<T>: IEnumerable<T>
    {
        class MyNumerator<T> : IEnumerator<T>
        {
            DoublePoint<T> beg;
            DoublePoint<T> current;
            public MyNumerator(DoubleList<T> collection)
            {
                beg = collection.beg;
                current = null;
            }
            public T Current
            {
                get { return current.data; }
            }
            object IEnumerator.Current
            {
                get { return current; }
            }

            //T IEnumerator<T>.Current => throw new NotImplementedException();
            //T IEnumerator<T>.Current
            //{
            //    get { throw  new NotImplementedException(); }
            //}

            public void Dispose()
            { }
            public bool MoveNext()
            {
                if (current == null)
                    current = beg;
                else
                    current = current.next;
                return current != null;
            }
            public void Reset()
            {
                current = this.beg;
            }
        }
        //методы для нумератора двусвязного списка
        public IEnumerator<T> GetEnumerator()
        {
            return new MyNumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        //конец методов для нумератора
        public DoubleList()
        { }
        public DoubleList(params T[]mas)
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
        public void Delete(int nom)
        {
            DoublePoint<T> dp1;
            DoublePoint<T> dp = beg;
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
        public void Add(int nom, params T[]mas)
        {
            DoublePoint<T> p1 = beg;
            DoublePoint<T> temp1 = new DoublePoint<T>(mas[rnd.Next(0,mas.Length-1)]);
            DoublePoint<T> vr1;
            DoublePoint<T> vr2;
            DoublePoint<T> p2 = beg;
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
        public void FindInColl(DoublePoint<Organization> beg, int employee)
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
