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

        ~VectorDecimal()
        {
            Console.WriteLine("Vector has been destructed.");
        }

        public void InputElements()
        {
            for (int i = 0; i < ArrayDecimal.Length; i++)
            {
                Console.Write($"Enter element {i + 1}: ");
                if (!decimal.TryParse(Console.ReadLine(), out ArrayDecimal[i]))
                {
                    Console.WriteLine("Invalid input! Please enter a valid decimal.");
                    i--;
                }
            }
        }

        public void PrintElements()
        {
            Console.WriteLine("Vector elements:");
            foreach (var element in ArrayDecimal)
            {
                Console.WriteLine(element);
            }
        }

        public void AssignValue(decimal value)
        {
            for (int i = 0; i < ArrayDecimal.Length; i++)
            {
                ArrayDecimal[i] = value;
            }
        }
        public static uint CountVectors()
        {
            return num_vec;
        }

        public uint Size
        {
            get { return num; }
        }

        public int CodeError
        {
            get { return codeError; }
            set { codeError = value; }
        }

        public decimal this[int index]
        {
            get
            {
                if (index < 0 || index >= ArrayDecimal.Length)
                {
                    codeError = -1;
                    return 0;
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

        public static VectorDecimal operator ++(VectorDecimal vector)
        {
            for (int i = 0; i < vector.ArrayDecimal.Length; i++)
            {
                vector.ArrayDecimal[i]++;
            }
            return vector;
        }

        public static VectorDecimal operator --(VectorDecimal vector)
        {
            for (int i = 0; i < vector.ArrayDecimal.Length; i++)
            {
                vector.ArrayDecimal[i]--;
            }
            return vector;
        }

        public static bool operator true(VectorDecimal vector)
        {
            if (vector.num != 0)
            {
                foreach (var element in vector.ArrayDecimal)
                {
                    if (element != 0)
                        return true;
                }
            }
            return false;
        }

        public static bool operator false(VectorDecimal vector)
        {
            return !vector;
        }

        public static bool operator !(VectorDecimal vector)
        {
            return vector.num != 0;
        }

        public static VectorDecimal operator ~(VectorDecimal vector)
        {
            for (int i = 0; i < vector.ArrayDecimal.Length; i++)
            {
                vector.ArrayDecimal[i] = (decimal)~(int)vector.ArrayDecimal[i];
            }
            return vector;
        }

        public static VectorDecimal operator +(VectorDecimal vector1, VectorDecimal vector2)
        {
            if (vector1.Size != vector2.Size)
            {
                Console.WriteLine("Vectors must have the same size to perform addition.");
                return null;
            }

            VectorDecimal result = new VectorDecimal(vector1.Size);

            for (int i = 0; i < result.Size; i++)
            {
                result[i] = vector1[i] + vector2[i];
            }

            return result;
        }

        public static VectorDecimal operator +(VectorDecimal vector, decimal scalar)
        {
            VectorDecimal result = new VectorDecimal(vector.Size);

            for (int i = 0; i < result.Size; i++)
            {
                result[i] = vector[i] + scalar;
            }

            return result;
        }

        public static VectorDecimal operator -(VectorDecimal vector1, VectorDecimal vector2)
        {
            if (vector1.Size != vector2.Size)
            {
                Console.WriteLine("Vectors must have the same size to perform subtraction.");
                return null;
            }

            VectorDecimal result = new VectorDecimal(vector1.Size);

            for (int i = 0; i < result.Size; i++)
            {
                result[i] = vector1[i] - vector2[i];
            }

            return result;
        }

        public static VectorDecimal operator -(VectorDecimal vector, decimal scalar)
        {
            VectorDecimal result = new VectorDecimal(vector.Size);

            for (int i = 0; i < result.Size; i++)
            {
                result[i] = vector[i] - scalar;
            }

            return result;
        }

        public static VectorDecimal operator *(VectorDecimal vector1, VectorDecimal vector2)
        {
            if (vector1.Size != vector2.Size)
            {
                Console.WriteLine("Vectors must have the same size to perform multiplication.");
                return null;
            }

            VectorDecimal result = new VectorDecimal(vector1.Size);

            for (int i = 0; i < result.Size; i++)
            {
                result[i] = vector1[i] * vector2[i];
            }

            return result;
        }

        public static VectorDecimal operator *(VectorDecimal vector, decimal scalar)
        {
            VectorDecimal result = new VectorDecimal(vector.Size);

            for (int i = 0; i < result.Size; i++)
            {
                result[i] = vector[i] * scalar;
            }

            return result;
        }

        public static VectorDecimal operator /(VectorDecimal vector1, VectorDecimal vector2)
        {
            if (vector1.Size != vector2.Size)
            {
                Console.WriteLine("Vectors must have the same size to perform division.");
                return null;
            }

            VectorDecimal result = new VectorDecimal(vector1.Size);

            for (int i = 0; i < result.Size; i++)
            {
                result[i] = vector1[i] / vector2[i];
            }

            return result;
        }

        public static VectorDecimal operator /(VectorDecimal vector, decimal scalar)
        {
            VectorDecimal result = new VectorDecimal(vector.Size);

            for (int i = 0; i < result.Size; i++)
            {
                result[i] = vector[i] / scalar;
            }

            return result;
        }

        public static VectorDecimal operator %(VectorDecimal vector1, VectorDecimal vector2)
        {
            if (vector1.Size != vector2.Size)
            {
                Console.WriteLine("Vectors must have the same size to perform modulo operation.");
                return null;
            }

            VectorDecimal result = new VectorDecimal(vector1.Size);

            for (int i = 0; i < result.Size; i++)
            {
                result[i] = vector1[i] % vector2[i];
            }

            return result;
        }

        public static VectorDecimal operator %(VectorDecimal vector, decimal scalar)
        {
            VectorDecimal result = new VectorDecimal(vector.Size);

            for (int i = 0; i < result.Size; i++)
            {
                result[i] = vector[i] % scalar;
            }

            return result;
        }

    }


    static void task2()
    {
        VectorDecimal vector = new VectorDecimal(3);

        Console.WriteLine("Enter elements of the vector:");
        vector.InputElements();

        vector.PrintElements();

        vector.AssignValue(5);

        vector.PrintElements();

        Console.WriteLine($"Number of vectors: {VectorDecimal.CountVectors()}");
        Console.WriteLine("Accessing vector elements using indexer:");
        for (int i = 0; i < vector.Size + 1; i++)
        {
            Console.WriteLine($"Element at index {i}: {vector[i]}, Error code: {vector.CodeError}");
        }

        VectorDecimal vector1 = new VectorDecimal(3);
        VectorDecimal vector2 = new VectorDecimal(3);
        decimal scalar = 10;

        Console.WriteLine("Enter elements of the first vector:");
        vector1.InputElements();

        Console.WriteLine("Enter elements of the second vector:");
        vector2.InputElements();

        VectorDecimal vectorSum = vector1 + vector2;
        if (vectorSum != null)
        {
            Console.WriteLine("Sum of vectors:");
            vectorSum.PrintElements();
        }
        VectorDecimal vectorScalarSum = vector1 + scalar;
        Console.WriteLine("Sum of first vector and scalar:");
        vectorScalarSum.PrintElements();

        VectorDecimal vectorMinus = vector1 - vector2;
        if (vectorMinus != null)
        {
            Console.WriteLine("Difference of vectors:");
            vectorMinus.PrintElements();
        }
        VectorDecimal vectorScalarMinus = vector1 - scalar;
        Console.WriteLine("Difference of first vector and scalar:");
        vectorScalarMinus.PrintElements();

        VectorDecimal vectorMult = vector1 * vector2;
        if (vectorMult != null)
        {
            Console.WriteLine("Element-wise multiplication of vectors:");
            vectorMult.PrintElements();
        }
        VectorDecimal vectorScalarMult = vector1 * scalar;
        Console.WriteLine("Multiplication of first vector by scalar:");
        vectorScalarMult.PrintElements();

        VectorDecimal vectorDivision = vector1 / vector2;
        if (vectorDivision != null)
        {
            Console.WriteLine("Element-wise division of vectors:");
            vectorDivision.PrintElements();
        }
        VectorDecimal vectorScalarDivision = vector1 / scalar;
        Console.WriteLine("Division of first vector by scalar:");
        vectorScalarDivision.PrintElements();

        VectorDecimal vectorRem = vector1 % vector2;
        if (vectorRem != null)
        {
            Console.WriteLine("Element-wise remainder of vectors:");
            vectorRem.PrintElements();
        }
        VectorDecimal vectorScalarRem = vector1 % scalar;
        Console.WriteLine("Remainder of first vector by scalar:");
        vectorScalarRem.PrintElements();
    }



    class DecimalMatrix
    {
        protected decimal[,] DCArray;
        protected uint n, m;
        protected int codeError;
        protected static int num_mf;

        // Конструктор без параметрів
        public DecimalMatrix()
        {
            n = 1;
            m = 1;
            DCArray = new decimal[n, m];
            codeError = 0;
            num_mf++;
        }

        // Конструктор із двома параметрами
        public DecimalMatrix(uint n, uint m)
        {
            this.n = n;
            this.m = m;
            DCArray = new decimal[n, m];
            codeError = 0;
            num_mf++;
        }

        // Конструктор із трьома параметрами
        public DecimalMatrix(uint n, uint m, decimal initialValue)
        {
            this.n = n;
            this.m = m;
            DCArray = new decimal[n, m];
            for (uint i = 0; i < n; i++)
            {
                for (uint j = 0; j < m; j++)
                {
                    DCArray[i, j] = initialValue;
                }
            }
            codeError = 0;
            num_mf++;
        }

        // Деструктор
        ~DecimalMatrix()
        {
            Console.WriteLine("Матриця була знищена.");
        }

        // Метод для вводу елементів матриці з клавіатури
        public void InputElements()
        {
            for (uint i = 0; i < n; i++)
            {
                for (uint j = 0; j < m; j++)
                {
                    Console.Write("Елемент [{0}, {1}]: ", i, j);
                    DCArray[i, j] = Convert.ToDecimal(Console.ReadLine());
                }
            }
        }

        // Метод для виводу елементів матриці на екран
        public void DisplayElements()
        {
            for (uint i = 0; i < n; i++)
            {
                for (uint j = 0; j < m; j++)
                {
                    Console.Write(DCArray[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        // Метод для присвоєння всім елементам матриці певного значення
        public void Assign(decimal value)
        {
            for (uint i = 0; i < n; i++)
            {
                for (uint j = 0; j < m; j++)
                {
                    DCArray[i, j] = value;
                }
            }
        }

        public static int CountMatrices()
        {
            return num_mf;
        }

        // Властивість для отримання розмірності матриці
        public uint[] Dimensions
        {
            get { return new uint[] { n, m }; }
        }

        // Властивість для отримання і встановлення коду помилки
        public int ErrorCode
        {
            get { return codeError; }
            set { codeError = value; }
        }

        // Індексатор з двома індексами
        public decimal this[uint i, uint j]
        {
            get
            {
                if (i < n && j < m)
                    return DCArray[i, j];
                else
                {
                    codeError = -1;
                    return 0;
                }
            }
            set
            {
                if (i < n && j < m)
                    DCArray[i, j] = value;
                else
                    codeError = -1;
            }
        }

        // Індексатор з одним індексом
        public decimal this[uint k]
        {
            get
            {
                uint i = k / m;
                uint j = k % m;
                if (i < n && j < m)
                    return DCArray[i, j];
                else
                {
                    codeError = -1;
                    return 0;
                }
            }
            set
            {
                uint i = k / m;
                uint j = k % m;
                if (i < n && j < m)
                    DCArray[i, j] = value;
                else
                    codeError = -1;
            }
        }

        // Перевантаження унарних операцій
        public static DecimalMatrix operator ++(DecimalMatrix dm)
        {
            for (uint i = 0; i < dm.n; i++)
            {
                for (uint j = 0; j < dm.m; j++)
                {
                    dm.DCArray[i, j]++;
                }
            }
            return dm;
        }

        public static DecimalMatrix operator --(DecimalMatrix dm)
        {
            for (uint i = 0; i < dm.n; i++)
            {
                for (uint j = 0; j < dm.m; j++)
                {
                    dm.DCArray[i, j]--;
                }
            }
            return dm;
        }

        public static bool operator true(DecimalMatrix dm)
        {
            for (uint i = 0; i < dm.n; i++)
            {
                for (uint j = 0; j < dm.m; j++)
                {
                    if (dm.DCArray[i, j] == 0)
                        return false;
                }
            }
            return true;
        }

        public static bool operator false(DecimalMatrix dm)
        {
            for (uint i = 0; i < dm.n; i++)
            {
                for (uint j = 0; j < dm.m; j++)
                {
                    if (dm.DCArray[i, j] == 0)
                        return true;
                }
            }
            return false;
        }

        public static bool operator !(DecimalMatrix dm)
        {
            return dm.n != 0 && dm.m != 0;
        }

        public static DecimalMatrix operator ~(DecimalMatrix dm)
        {
            for (uint i = 0; i < dm.n; i++)
            {
                for (uint j = 0; j < dm.m; j++)
                {
                    long intValue = decimal.ToInt64(dm.DCArray[i, j]);
                    intValue = ~intValue;
                    dm.DCArray[i, j] = decimal.FromOACurrency(intValue);
                }
            }
            return dm;
        }
    }

    static void task3()
    {
        DecimalMatrix matrix = new DecimalMatrix(2, 3, 5); // Створення матриці розміром 2x3 зі значенням ініціалізації 5
        Console.WriteLine("Size of matrix: {0}x{1}", matrix.Dimensions[0], matrix.Dimensions[1]);
        Console.WriteLine("Element of matrix:");
        matrix.DisplayElements();

        matrix[0, 1] = 10; // Приклад використання індексатора з двома індексами
        Console.WriteLine("\nMatrix after change [0, 1]:");
        matrix.DisplayElements();

        Console.WriteLine("\nChange all elements to 8:");
        matrix.Assign(8); // Приклад використання методу Assign
        matrix.DisplayElements();

        Console.WriteLine("\nEnter new element:");
        matrix.InputElements(); // Введення нових значень з клавіатури
        Console.WriteLine("\nElement after change:");
        matrix.DisplayElements();

        Console.WriteLine("\nThe number of matrix: {0}", DecimalMatrix.CountMatrices());

        Console.ReadKey();
    }
}

