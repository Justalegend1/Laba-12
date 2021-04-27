using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;

namespace Lab12Var4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите задание\n1\n2");
            bool q = Int32.TryParse(Console.ReadLine(), out int task);
            while (!q)
            {
                Console.WriteLine("Введите цифру!");
                q = Int32.TryParse(Console.ReadLine(), out task);
            }
            while ((task < 1) | (task > 2))
            {
                Console.WriteLine("Введиет цифру от 1 до 2");
                q = Int32.TryParse(Console.ReadLine(), out task);
            }
            switch (task)
            {
                case 1:
            Organization k = new Organization();
            Organization Org = new Organization("Организация", 235);
            Factory Fac = new Factory("Фабрика", 450, 35, "Лондон");
            Insurance_Company Ins = new Insurance_Company("Страховая компания", 600, 1990, 98);
            Library Lib = new Library("Библиотека", 500, 7, 700);
            Shipbuilding_company Ship = new Shipbuilding_company("Кораблестроительная фирма", 490, 900000, 35);
            Organization[] mas = new Organization[5] { Org, Fac, Ins, Lib, Ship };
            List<Organization> list1 = new List<Organization>(mas);
            list1.PrintList();
            Console.ReadKey();
            Organization l = new Organization();
            Point<Organization> p; /*= list1.FindLast();*/
            //Console.WriteLine(p.ToString());
            Organization[] mas1 = new Organization[5];
            //for (int i = 0; i < mas.Length; i++)
            //    mas1[i] = mas[mas.Length - 1 - i];
            //foreach (Organization g in mas1)
            //    g.Show();
            Console.WriteLine("Удаляем первый элемент с четным информационным полем");
            p = list1.beg;
            if (p.data.Number_of_employees % 2 == 0)
                p = null;
            else
                while (p.next.data.Number_of_employees % 2 != 0)
                    p = p.next;
            p.next = p.next.next;
            list1.PrintList();
            Console.ReadKey();
            Console.WriteLine("Сотрем весь список из памяти");
            //List<Organization>.Point<Organization> Po;
            list1.beg = null;
            list1.PrintList();
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Создадим двусвязный список");
            DoubleList<Organization> list2 = new DoubleList<Organization>(mas);
            list2.PrintList();
            Console.ReadKey();
            Console.WriteLine("Элемент с каким номером вы хотите добавить?\n1\n2\n3\n4\n5\n6");
            int nom;
            bool o = Int32.TryParse(Console.ReadLine(), out nom);
            Factory fac1 = new Factory("Фабрика 2", 270, 50, "Париж");
            while (!o)
            {
                Console.WriteLine("Введите число");
                o = Int32.TryParse(Console.ReadLine(), out nom);
            }
            while ((nom > 6) | (nom < 1))
            {
                Console.WriteLine("Введите число от 1 до 6");
                o = Int32.TryParse(Console.ReadLine(), out nom);
            }
            DoubleList<Organization>.DoublePoint<Organization> p2 = list2.beg;
            for (int i = 1; i < nom; i++)
                p2 = p2.next;
            DoubleList<Organization>.DoublePoint<Organization> vr2;
            vr2 = p2;
            DoubleList<Organization>.DoublePoint<Organization> p1 = list2.beg;
            DoubleList<Organization>.DoublePoint<Organization> temp1 = new DoubleList<Organization>.DoublePoint<Organization>(fac1);
            for (int i = 1; i < nom - 1; i++)
                p1 = p1.next;
            vr2 = p2;
            DoubleList<Organization>.DoublePoint<Organization> vr1;
            vr1 = p1;
            p1.next = temp1;
            p1 = p1.next;
            p1.pred = vr1;
            p1.next = vr2;
            Console.WriteLine("Добавляем элемент в список");
            list2.PrintList();
            Console.ReadKey();
            Console.WriteLine("Удаляем список из памяти");
            list2.beg = null;
            list2.PrintList();
            Console.ReadKey();
            Console.WriteLine("Создадим идеально сбалансированное бинарное дерево");
            int size;
            Point<Organization> Tree = new Point<Organization>();
            Point<Organization> p3 = new Point<Organization>();
            Console.WriteLine("Введите размер дерева");
            bool o1 = Int32.TryParse(Console.ReadLine(), out size);
            while (!o1)
            {
                Console.WriteLine("Введите число");
                o1 = Int32.TryParse(Console.ReadLine(), out size);
            }
            while (size < 0)
            {
                Console.WriteLine("Введите положительное число");
                o1 = Int32.TryParse(Console.ReadLine(), out size);
            }
            Tree = Point<Organization>.IdealTree1(size, p3);
            Point<Organization>.ShowTree(Point<Organization>.Root, 3);
            Console.ReadKey();
            Console.WriteLine("Найдем минимальный элемент в дереве");
            Organization org;
            org = Tree.Run(Point<Organization>.Root);//нужно подать корень в качестве параметра
            Console.WriteLine(org.ToString());
            Console.ReadKey();
            Console.WriteLine("Преобразуем идеальное дерево в дерево поиска");
                Point<Organization> Root1 = Point<Organization>.Add(null, Point<Organization>.Root.data);
                    //Point<Organization> NewPoint = new Point<Organization>(Ship);
                    Point<Organization>.Root = Point<Organization>.Add(null, Point<Organization>.Root.data);
                    Point<Organization>.recAdd(Point<Organization>.Root, Point<Organization>.Root);
                    //Point<Organization> FindTree = new Point<Organization>();
                    //foreach (Organization op in mas)
                    //    if (op == Point<Organization>.Root.data)
                    //        continue;
                    //    else
                    //        FindTree = Point<Organization>.Add(NewRoot, op);
                    Point<Organization>.ShowTree(Point<Organization>.Root, 1);
                    Console.ReadKey();
                    break;
                case 2:
                    Organization k1 = new Organization();
                    Organization Org1 = new Organization("Организация", 235);
                    Factory Fac1 = new Factory("Фабрика", 450, 35, "Лондон");
                    Insurance_Company Ins1 = new Insurance_Company("Страховая компания", 600, 1990, 98);
                    Library Lib1 = new Library("Библиотека", 500, 7, 700);
                    Shipbuilding_company Ship1 = new Shipbuilding_company("Кораблестроительная фирма", 490, 900000, 35);
                    Organization[] mas4 = new Organization[5] { Org1, Fac1, Ins1, Lib1, Ship1 };
                    Console.WriteLine("Кольцевой двусвязный список");
                    DoubleListConnection<Organization> list3 = new DoubleListConnection<Organization>(mas4);
                    Console.ReadKey();
                    Console.WriteLine("Перебор элементов коллекции");
                    List<Organization> list_ = new List<Organization>(mas4);
                    foreach (Organization op in list_)
                        Console.WriteLine(op);
                    Console.ReadKey();
                    break;
        }
        }
    }
}
