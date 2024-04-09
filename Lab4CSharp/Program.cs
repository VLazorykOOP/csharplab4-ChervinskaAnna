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
        Console.WriteLine("Operator--" + Operator2);

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
        Console.WriteLine("Operator*" + Operator3);
    }


    class VectorDecimal
    {
        decimal[] ArrayDecimal;
        uint num;
        int codeError;
        static uint num_vec;

        // Конструктори
        public VectorDecimal()
        {
            ArrayDecimal = new decimal[1];
            num = 1;
            codeError = 0;
            num_vec++;
        }
        public VectorDecimal(uint size)
        {
            ArrayDecimal = new decimal[size];
            num = size;
            codeError = 0;
            num_vec++;
        }
        public VectorDecimal(uint size, decimal initValue)
        {
            ArrayDecimal = new decimal[size];
            num = size;
            codeError = 0;
            num_vec++;

            for (int i = 0; i < size; i++)
            {
                ArrayDecimal[i] = initValue;
            }
        }

        // Деструктор
        ~VectorDecimal()
        {
            Console.WriteLine("Vector has been destructed.");
        }

        // Метод, що дозволяє ввести елементи вектора з клавіатури
        public void InputElements()
        {
            for (int i = 0; i < ArrayDecimal.Length; i++)
            {
                Console.Write($"Enter element {i + 1}: ");
                if (!decimal.TryParse(Console.ReadLine(), out ArrayDecimal[i]))
                {
                    Console.WriteLine("Invalid input! Please enter a valid decimal.");
                    i--; // Повторення для введення коректного значення
                }
            }
        }

        // Метод, що дозволяє вивести елементи вектора на екран
        public void PrintElements()
        {
            Console.WriteLine("Vector elements:");
            foreach (var element in ArrayDecimal)
            {
                Console.WriteLine(element);
            }
        }

        // Метод, що присвоює елементам масиву вектора деяке значення
        public void AssignValue(decimal value)
        {
            for (int i = 0; i < ArrayDecimal.Length; i++)
            {
                ArrayDecimal[i] = value;
            }
        }

        // Статичний метод, що підраховує кількість векторів даного типу
        public static uint CountVectors()
        {
            return num_vec;
        }

        // Властивість, що повертає розмірність вектора
        public uint Size
        {
            get { return num; }
        }

        // Властивість для доступу до поля codeError
        public int CodeError
        {
            get { return codeError; }
            set { codeError = value; }
        }

        // Індексатор
        public decimal this[int index]
        {
            get
            {
                if (index < 0 || index >= ArrayDecimal.Length)
                {
                    codeError = -1;
                    return 0; // Повертаємо дефолтне значення
                }
                else
                {
                    codeError = 0;
                    return ArrayDecimal[index];
                }
            }
            set
            {
                if (index < 0 || index >= ArrayDecimal.Length)
                {
                    codeError = -1;
                }
                else
                {
                    ArrayDecimal[index] = value;
                    codeError = 0;
                }
            }
        }

    }
    static void task2()
    {
        // Створення об'єкту вектора
        VectorDecimal vector = new VectorDecimal(3);

        // Ввід елементів вектора з клавіатури
        Console.WriteLine("Enter elements of the vector:");
        vector.InputElements();

        // Виведення елементів вектора на екран
        vector.PrintElements();

        // Присвоєння всім елементам вектора деякого значення
        vector.AssignValue(5);

        // Виведення зміненої структури вектора
        vector.PrintElements();

        // Підрахунок кількості векторів
        Console.WriteLine($"Number of vectors: {VectorDecimal.CountVectors()}");

        // Використання індексатора
        Console.WriteLine("Accessing vector elements using indexer:");
        for (int i = 0; i < vector.Size + 1; i++)
        {
            Console.WriteLine($"Element at index {i}: {vector[i]}, Error code: {vector.CodeError}");
        }
    }

    static void task3()
    {

    }
}
