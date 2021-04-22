//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Lab12Var4
//{
//    public class IdealTree<T>
//    {
//        static Organization GetInfo()
//        {
//            Random rnd = new Random();
//            Organization k = new Organization();
//            Organization Org = new Organization("Организация", 235);
//            Factory Fac = new Factory("Фабрика", 450, 35, "Лондон");
//            Insurance_Company Ins = new Insurance_Company("Страховая компания", 600, 1990, 98);
//            Library Lib = new Library("Библиотека", 500, 7, 700);
//            Shipbuilding_company Ship = new Shipbuilding_company("Кораблестроительная фирма", 490, 900000, 35);
//            Organization[] mas = new Organization[5] { Org, Fac, Ins, Lib, Ship };
//            Organization info = mas[rnd.Next(0, mas.Length - 1)];
//            return info;
//        }
//        public static List<Organization>.Point<Organization> IdealTree1(int size, List<Organization>.Point<Organization> p)
//        {
//            List<Organization>.Point<Organization> r;
//            int nl, nr;
//            if (size == 0) { p = null; return p; }
//            nl = size / 2; nr = size - nl - 1;
//            Organization d = GetInfo();
//            r = new List<Organization>.Point<Organization>(d);
//            r.left = IdealTree1(nl, r.left);
//            r.right = IdealTree1(nr, r.right);
//            return r;
//        }
//        static void ShowTree(List<Organization>.Point<Organization> p, int l)
//        {
//            if (p != null)
//            {
//                ShowTree(p.left, l + 3);
//                for (int i = 0; i < l; i++)
//                    Console.Write(" ");
//                Console.WriteLine(p.data);
//                ShowTree(p.right, l + 3);
//            }
//        }
//    }
//}
