using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What task do you want?");
        Console.WriteLine("1. Task 1");
        Console.WriteLine("2. Task 2");
        Console.WriteLine("3. Task 3");
        Console.WriteLine("4. Exit");

        int choice;
        bool isValidChoice = false;

        do
        {
            Console.Write("Enter number of task: ");
            isValidChoice = int.TryParse(Console.ReadLine(), out choice);

            if (!isValidChoice || choice < 1 || choice > 4)
            {
                Console.WriteLine("This task does not exist");
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

    class ITriangle
    {
        private double a, b;
        private string color;

        public ITriangle(double a, double b, string color)
        {
            this.a = a;
            this.b = b;
            this.color = color;
        }

        public object this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return a;
                    case 1:
                        return b;
                    case 2:
                        return color;
                    default:
                        throw new IndexOutOfRangeException($"Index {index} is out of range. Only indices 0, 1, and 2 are allowed.");
                }
            }
        }

        public static ITriangle operator ++(ITriangle triangle)
        {
            triangle.a++;
            triangle.b++;
            return triangle;
        }

        public static ITriangle operator --(ITriangle triangle)
        {
            triangle.a--;
            triangle.b--;
            return triangle;
        }

        public static bool operator true(ITriangle triangle)
        {
            return (triangle.a + triangle.a > triangle.b);
        }

        public static bool operator false(ITriangle triangle)
        {
            return !(triangle.a + triangle.a > triangle.b);
        }

        public static ITriangle operator *(ITriangle triangle, int [] scalar)
        {
            triangle.a *= scalar[0];
            triangle.b *= scalar[1];
            return (triangle);
        }

        public override string ToString() {

            return $"a: {this.a}; b: {this.b}; color: {this.color} ";
        }
    }

    static void task1()
    {
        ITriangle triangle = new ITriangle(3, 4, "Red");
        Console.WriteLine(triangle[0]);
        Console.WriteLine(triangle[1]);
        Console.WriteLine(triangle[2]);

        ITriangle Operator1 = triangle++;
        Console.WriteLine("Operator++" + Operator1);
        ITriangle Operator2 = triangle--;
        Console.WriteLine("Operator2" + Operator2);

        ITriangle anothertriangle = new ITriangle(2, 12, "Blue");

        if (triangle)
        {
            Console.WriteLine($"triangle {triangle} exists");
        }
        else {
            Console.WriteLine($"triangle {triangle} doesn't exists");
        }

        if (anothertriangle)
        {
            Console.WriteLine($"triangle {anothertriangle} exists");
        }
        else
        {
            Console.WriteLine($"triangle {anothertriangle} doesn't exists");
        }

        int[]Scalar = new int[2] { 2, 3 };
        ITriangle Operator3 = triangle * Scalar;
        Console.WriteLine("Operator3" + Operator3);
    }

    static void task2()
    {

    }

    static void task3()
    {

    }
}
