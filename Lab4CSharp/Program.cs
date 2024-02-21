using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using static Lab4CSharp.Lab4;

namespace Lab4CSharp
{
    class Lab4
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What task do you want?");
            Console.WriteLine("1. Task 1");
            Console.WriteLine("2. Task 2");
            Console.WriteLine("3. Task 2");
            Console.WriteLine("4. Exit");

            int choice;
            bool isValidChoice = false;

            do
            {
                Console.Write("Enter number of task ");
                isValidChoice = int.TryParse(Console.ReadLine(), out choice);

                if (!isValidChoice || choice < 1 || choice > 4)
                {
                    Console.WriteLine("This task not exist");
                    isValidChoice = false;
                }
            } while (!isValidChoice);
            switch (choice)
            {
                case 1:
                    task1();
                    break;
                case 2:
                    task2();
                    break;
                case 3:
                    task3();
                    break;
                case 4:
                    break;
            }
        }

        public class ITriangle
        {
            protected int a, b;
            protected int c;
            public ITriangle(int Base, int side, int color)
            {
                a = Base;
                b = side;
                c = color;
            }
            public int this[int i]
            {
                get
                {
                    if (i < 0 || i >= 3) throw new Exception("Error");
                    else if (i == 0) return a;
                    else if (i == 1) return b;
                    else
                    {
                        return c;
                    }
                }
            }
        }
       

        static void task1()
        {
            Console.Write("Enter index of value = ");
            int n = int.Parse(Console.ReadLine());
            var array = new ITriangle(3, 5, 6);
            try
            {
                Console.WriteLine($"a[{n}]={array[n]}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }



        static void task2()
        {


        }
        static void task3()
        {


        }
    }
}
