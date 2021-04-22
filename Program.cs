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
            Organization k = new Organization();
            Organization Org = new Organization("Организация",235);
            Factory Fac = new Factory("Фабрика", 450, 35,"Лондон");
            Insurance_Company Ins = new Insurance_Company("Страховая компания", 600, 1990, 98);
            Library Lib = new Library("Библиотека", 500, 7, 700);
            Shipbuilding_company Ship = new Shipbuilding_company("Кораблестроительная фирма", 490, 900000, 35);
            Organization[] mas = new Organization[5] { Org, Fac, Ins, Lib, Ship }; 
            List<Organization> list1 = new List<Organization>(mas);
            list1.PrintList();
            Console.ReadKey();
            Organization l = new Organization();
            List<Organization>.Point<Organization> p; /*= list1.FindLast();*/
            //Console.WriteLine(p.ToString());
            Organization [] mas1 = new Organization [5];
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
            for (int i = 1; i < nom-1; i++)
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
            List<Organization>.Point < Organization > Tree = new List<Organization>.Point<Organization>();
            List<Organization>.Point<Organization> p3 = new List<Organization>.Point<Organization>();
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
            Tree = List<Organization>.Point<Organization>.IdealTree1(size, p3);
            List<Organization>.Point<Organization>.ShowTree(List<Organization>.Point<Organization>.Root, 3);
            Console.ReadKey();
            Console.WriteLine("Найдем минимальный элемент в дереве");
            Organization org;
            org = Tree.Run(List<Organization>.Point<Organization>.Root);//нужно подать корень в качестве параметра
            Console.WriteLine(org.ToString());
            Console.ReadKey();
            Console.WriteLine("Преобразуем идеальное дерево в дерево поиска");
            List<Organization>.Point<Organization> NewRoot = new List<Organization>.Point<Organization>(org);
            List<Organization>.Point<Organization> FindTree = new List<Organization>.Point<Organization>();
            foreach (Organization op in mas)
                if (op == List<Organization>.Point<Organization>.Root.data)
                    continue;
                else
                    FindTree = FindTree.Add(NewRoot, op);
            List<Organization>.Point<Organization>.ShowTree(FindTree, 1);
            Console.ReadKey();
        }
    }
}
