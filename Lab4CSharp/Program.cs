using System;
using System.Numerics;

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

        public static ITriangle operator *(ITriangle triangle, int[] scalar)
        {
            triangle.a *= scalar[0];
            triangle.b *= scalar[1];
            return (triangle);
        }

        public override string ToString()
        {

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
        else
        {
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

        int[] Scalar = new int[2] { 2, 3 };
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


        public static VectorDecimal operator |(VectorDecimal vector1, VectorDecimal vector2)
        {
            if (vector1.Size != vector2.Size)
            {
                Console.WriteLine("Vectors must have the same size to perform bitwise OR.");
                return null;
            }

            VectorDecimal result = new VectorDecimal(vector1.Size);

            for (int i = 0; i < result.Size; i++)
            {
                result[i] = (decimal)((int)vector1[i] | (int)vector2[i]);
            }

            return result;
        }

        public static VectorDecimal operator |(VectorDecimal vector, decimal scalar)
        {
            VectorDecimal result = new VectorDecimal(vector.Size);
            for (int i = 0; i < result.Size; i++)
            {
                result[i] = (decimal)((int)vector[i] | (int)scalar);
            }
            return result;
        }

        public static VectorDecimal operator ^(VectorDecimal vector1, VectorDecimal vector2)
        {
            if (vector1.Size != vector2.Size)
            {
                Console.WriteLine("Vectors must have the same size to perform bitwise XOR.");
                return null;
            }

            VectorDecimal result = new VectorDecimal(vector1.Size);

            for (int i = 0; i < result.Size; i++)
            {
                result[i] = (decimal)((int)vector1[i] ^ (int)vector2[i]);
            }

            return result;
        }


        public static VectorDecimal operator ^(VectorDecimal vector, decimal scalar)
        {
            VectorDecimal result = new VectorDecimal(vector.Size);
            for (int i = 0; i < result.Size; i++)
            {
                result[i] = (decimal)((int)vector[i] ^ (int)scalar);
            }
            return result;
        }

        public static VectorDecimal operator &(VectorDecimal vector1, VectorDecimal vector2)
        {
            if (vector1.Size != vector2.Size)
            {
                Console.WriteLine("Vectors must have the same size to perform bitwise AND.");
                return null;
            }

            VectorDecimal result = new VectorDecimal(vector1.Size);

            for (int i = 0; i < result.Size; i++)
            {
                result[i] = (decimal)((int)vector1[i] & (int)vector2[i]);
            }

            return result;
        }

        public static VectorDecimal operator &(VectorDecimal vector, decimal scalar)
        {
            VectorDecimal result = new VectorDecimal(vector.Size);
            for (int i = 0; i < result.Size; i++)
            {
                result[i] = (decimal)((int)vector[i] & (int)scalar);
            }
            return result;
        }
        public static VectorDecimal operator >>(VectorDecimal vector, int shift)
        {
            VectorDecimal result = new VectorDecimal(vector.Size);

            for (int i = 0; i < result.Size; i++)
            {
                result[i] = (decimal)((int)vector[i] >> shift);
            }

            return result;
        }

        public static VectorDecimal operator <<(VectorDecimal vector, int shift)
        {
            VectorDecimal result = new VectorDecimal(vector.Size);

            for (int i = 0; i < result.Size; i++)
            {
                result[i] = (decimal)((int)vector[i] << shift);
            }

            return result;
        }

        public static bool operator ==(VectorDecimal vector1, VectorDecimal vector2)
        {
            if (object.ReferenceEquals(vector1, null) || object.ReferenceEquals(vector2, null))
            {
                return false;
            }

            if (vector1.Size != vector2.Size)
            {
                return false;
            }

            for (int i = 0; i < vector1.Size; i++)
            {
                if (vector1[i] != vector2[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool operator !=(VectorDecimal vector1, VectorDecimal vector2)
        {
            return !(vector1 == vector2);
        }

        public static bool operator >(VectorDecimal vector1, VectorDecimal vector2)
        {
            if (vector1.Size != vector2.Size)
            {
                Console.WriteLine("Vectors must have the same size to perform comparison.");
                return false;
            }

            for (int i = 0; i < vector1.Size; i++)
            {
                if (vector1[i] <= vector2[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool operator >=(VectorDecimal vector1, VectorDecimal vector2)
        {
            if (vector1.Size != vector2.Size)
            {
                Console.WriteLine("Vectors must have the same size to perform comparison.");
                return false;
            }

            for (int i = 0; i < vector1.Size; i++)
            {
                if (vector1[i] < vector2[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool operator <(VectorDecimal vector1, VectorDecimal vector2)
        {
            if (vector1.Size != vector2.Size)
            {
                Console.WriteLine("Vectors must have the same size to perform comparison.");
                return false;
            }

            for (int i = 0; i < vector1.Size; i++)
            {
                if (vector1[i] >= vector2[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool operator <=(VectorDecimal vector1, VectorDecimal vector2)
        {
            if (vector1.Size != vector2.Size)
            {
                Console.WriteLine("Vectors must have the same size to perform comparison.");
                return false;
            }

            for (int i = 0; i < vector1.Size; i++)
            {
                if (vector1[i] > vector2[i])
                {
                    return false;
                }
            }

            return true;
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
            Console.WriteLine("Multiplication of vectors:");
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

        Console.WriteLine("\nBitwise OR operation between vector1 and vector2:");
        VectorDecimal bitwiseOR = vector1 | vector2;
        bitwiseOR.PrintElements();

        Console.WriteLine("\nBitwise OR operation between vector1 and scalar:");
        VectorDecimal bitwiseORScalar = vector1 | 5;
        bitwiseORScalar.PrintElements();

        Console.WriteLine("\nBitwise XOR operation between vector1 and vector2:");
        VectorDecimal bitwiseXOR = vector1 ^ vector2;
        bitwiseXOR.PrintElements();

        Console.WriteLine("\nBitwise XOR operation between vector1 and scalar:");
        VectorDecimal bitwiseXORScalar = vector1 ^ 5;
        bitwiseXORScalar.PrintElements();

        Console.WriteLine("\nBitwise AND operation between vector1 and vector2:");
        VectorDecimal bitwiseAND = vector1 & vector2;
        bitwiseAND.PrintElements();

        Console.WriteLine("\nBitwise AND operation between vector1 and scalar:");
        VectorDecimal bitwiseANDScalar = vector1 & 5;
        bitwiseANDScalar.PrintElements();

        Console.WriteLine("\nBitwise right shift operation of vector1 by 2 bits:");
        VectorDecimal rightShift = vector1 >> 2;
        rightShift.PrintElements();

        Console.WriteLine("\nBitwise left shift operation of vector1 by 2 bits:");
        VectorDecimal leftShift = vector1 << 2;
        leftShift.PrintElements();

        Console.WriteLine("\nEquality check between vector1 and vector2:");
        Console.WriteLine(vector1 == vector2);

        Console.WriteLine("\nInequality check between vector1 and vector2:");
        Console.WriteLine(vector1 != vector2);

        Console.WriteLine("\nComparison: vector1 greater than vector2:");
        Console.WriteLine(vector1 > vector2);

        Console.WriteLine("\nComparison: vector1 greater than or equal to vector2:");
        Console.WriteLine(vector1 >= vector2);

        Console.WriteLine("\nComparison: vector1 less than vector2:");
        Console.WriteLine(vector1 < vector2);

        Console.WriteLine("\nComparison: vector1 less than or equal to vector2:");
        Console.WriteLine(vector1 <= vector2);
    }



    class DecimalMatrix
    {
        protected decimal[,] DCArray;
        protected uint n, m;
        protected int codeError;
        protected static int num_mf;

        public DecimalMatrix()
        {
            n = 1;
            m = 1;
            DCArray = new decimal[n, m];
            codeError = 0;
            num_mf++;
        }

        public DecimalMatrix(uint n, uint m)
        {
            this.n = n;
            this.m = m;
            DCArray = new decimal[n, m];
            codeError = 0;
            num_mf++;
        }

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

        ~DecimalMatrix()
        {
            Console.WriteLine("Matrix has been destructed.");
        }

        public void InputElements()
        {
            for (uint i = 0; i < n; i++)
            {
                for (uint j = 0; j < m; j++)
                {
                    Console.Write("Element [{0}, {1}]: ", i, j);
                    DCArray[i, j] = Convert.ToDecimal(Console.ReadLine());
                }
            }
        }

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

        public uint[] Dimensions
        {
            get { return new uint[] { n, m }; }
        }

        public int ErrorCode
        {
            get { return codeError; }
            set { codeError = value; }
        }

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

        public static DecimalMatrix operator +(DecimalMatrix matrix1, DecimalMatrix matrix2)
        {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            {
                Console.WriteLine("Matrices must have the same dimensions to perform addition.");
                return null;
            }

            DecimalMatrix result = new DecimalMatrix(matrix1.n, matrix1.m);

            for (uint i = 0; i < matrix1.n; i++)
            {
                for (uint j = 0; j < matrix1.m; j++)
                {
                    result[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }

            return result;
        }

        public static DecimalMatrix operator +(DecimalMatrix matrix, decimal scalar)
        {
            DecimalMatrix result = new DecimalMatrix(matrix.n, matrix.m);

            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    result[i, j] = matrix[i, j] + scalar;
                }
            }

            return result;
        }

        public static DecimalMatrix operator -(DecimalMatrix matrix1, DecimalMatrix matrix2)
        {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            {
                Console.WriteLine("Matrices must have the same dimensions to perform subtraction.");
                return null;
            }

            DecimalMatrix result = new DecimalMatrix(matrix1.n, matrix1.m);

            for (uint i = 0; i < matrix1.n; i++)
            {
                for (uint j = 0; j < matrix1.m; j++)
                {
                    result[i, j] = matrix1[i, j] - matrix2[i, j];
                }
            }

            return result;
        }

        public static DecimalMatrix operator -(DecimalMatrix matrix, decimal scalar)
        {
            DecimalMatrix result = new DecimalMatrix(matrix.n, matrix.m);

            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    result[i, j] = matrix[i, j] - scalar;
                }
            }

            return result;
        }

        public static DecimalMatrix operator *(DecimalMatrix matrix1, DecimalMatrix matrix2)
        {
            if (matrix1.m != matrix2.n)
            {
                Console.WriteLine("The number of columns in the first matrix must be equal to the number of rows in the second matrix for multiplication.");
                return null;
            }

            DecimalMatrix result = new DecimalMatrix(matrix1.n, matrix2.m);

            for (uint i = 0; i < matrix1.n; i++)
            {
                for (uint j = 0; j < matrix2.m; j++)
                {
                    decimal sum = 0;
                    for (uint k = 0; k < matrix1.m; k++)
                    {
                        sum += matrix1[i, k] * matrix2[k, j];
                    }
                    result[i, j] = sum;
                }
            }

            return result;
        }

        public static DecimalMatrix operator *(DecimalMatrix matrix, decimal scalar)
        {
            DecimalMatrix result = new DecimalMatrix(matrix.n, matrix.m);

            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    result[i, j] = matrix[i, j] * scalar;
                }
            }

            return result;
        }

        public static DecimalMatrix operator /(DecimalMatrix matrix1, DecimalMatrix matrix2)
        {
            if (matrix1.m != matrix2.n)
            {
                Console.WriteLine("The number of columns in the first matrix must be equal to the number of rows in the second matrix for division.");
                return null;
            }

            // Assuming matrix2 is invertible
            // For simplicity, let's just return the product of matrix1 and the inverse of matrix2
            return matrix1 * Inverse(matrix2);
        }

        public static DecimalMatrix operator /(DecimalMatrix matrix, decimal scalar)
        {
            DecimalMatrix result = new DecimalMatrix(matrix.n, matrix.m);

            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    result[i, j] = matrix[i, j] / scalar;
                }
            }

            return result;
        }

        public static DecimalMatrix operator %(DecimalMatrix matrix1, DecimalMatrix matrix2)
        {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            {
                Console.WriteLine("Matrices must have the same dimensions to perform modulo operation.");
                return null;
            }

            DecimalMatrix result = new DecimalMatrix(matrix1.n, matrix1.m);

            for (uint i = 0; i < matrix1.n; i++)
            {
                for (uint j = 0; j < matrix1.m; j++)
                {
                    result[i, j] = matrix1[i, j] % matrix2[i, j];
                }
            }

            return result;
        }

        public static DecimalMatrix operator %(DecimalMatrix matrix, decimal scalar)
        {
            DecimalMatrix result = new DecimalMatrix(matrix.n, matrix.m);

            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    result[i, j] = matrix[i, j] % scalar;
                }
            }

            return result;
        }

        public static DecimalMatrix operator |(DecimalMatrix matrix1, DecimalMatrix matrix2)
        {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            {
                Console.WriteLine("Matrices must have the same dimensions to perform bitwise OR operation.");
                return null;
            }

            DecimalMatrix result = new DecimalMatrix(matrix1.n, matrix1.m);

            for (uint i = 0; i < matrix1.n; i++)
            {
                for (uint j = 0; j < matrix1.m; j++)
                {
                    long intValue1 = decimal.ToInt64(matrix1[i, j]);
                    long intValue2 = decimal.ToInt64(matrix2[i, j]);
                    long resultValue = intValue1 | intValue2;
                    result[i, j] = decimal.FromOACurrency(resultValue);
                }
            }

            return result;
        }

        public static DecimalMatrix operator |(DecimalMatrix matrix, decimal scalar)
        {
            DecimalMatrix result = new DecimalMatrix(matrix.n, matrix.m);

            long scalarValue = decimal.ToInt64(scalar);

            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    long intValue = decimal.ToInt64(matrix[i, j]);
                    long resultValue = intValue | scalarValue;
                    result[i, j] = decimal.FromOACurrency(resultValue);
                }
            }

            return result;
        }

        public static DecimalMatrix operator ^(DecimalMatrix matrix1, DecimalMatrix matrix2)
        {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            {
                Console.WriteLine("Matrices must have the same dimensions to perform bitwise XOR operation.");
                return null;
            }

            DecimalMatrix result = new DecimalMatrix(matrix1.n, matrix1.m);

            for (uint i = 0; i < matrix1.n; i++)
            {
                for (uint j = 0; j < matrix1.m; j++)
                {
                    long intValue1 = decimal.ToInt64(matrix1[i, j]);
                    long intValue2 = decimal.ToInt64(matrix2[i, j]);
                    long resultValue = intValue1 ^ intValue2;
                    result[i, j] = decimal.FromOACurrency(resultValue);
                }
            }

            return result;
        }

        public static DecimalMatrix operator ^(DecimalMatrix matrix, decimal scalar)
        {
            DecimalMatrix result = new DecimalMatrix(matrix.n, matrix.m);

            long scalarValue = decimal.ToInt64(scalar);

            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    long intValue = decimal.ToInt64(matrix[i, j]);
                    long resultValue = intValue ^ scalarValue;
                    result[i, j] = decimal.FromOACurrency(resultValue);
                }
            }

            return result;
        }

        public static DecimalMatrix operator &(DecimalMatrix matrix1, DecimalMatrix matrix2)
        {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            {
                Console.WriteLine("Matrices must have the same dimensions to perform bitwise AND operation.");
                return null;
            }

            DecimalMatrix result = new DecimalMatrix(matrix1.n, matrix1.m);

            for (uint i = 0; i < matrix1.n; i++)
            {
                for (uint j = 0; j < matrix1.m; j++)
                {
                    long intValue1 = decimal.ToInt64(matrix1[i, j]);
                    long intValue2 = decimal.ToInt64(matrix2[i, j]);
                    long resultValue = intValue1 & intValue2;
                    result[i, j] = decimal.FromOACurrency(resultValue);
                }
            }

            return result;
        }

        public static DecimalMatrix operator &(DecimalMatrix matrix, decimal scalar)
        {
            DecimalMatrix result = new DecimalMatrix(matrix.n, matrix.m);

            long scalarValue = decimal.ToInt64(scalar);

            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    long intValue = decimal.ToInt64(matrix[i, j]);
                    long resultValue = intValue & scalarValue;
                    result[i, j] = decimal.FromOACurrency(resultValue);
                }
            }

            return result;
        }

        public static DecimalMatrix operator >>(DecimalMatrix matrix, int shift)
        {
            DecimalMatrix result = new DecimalMatrix(matrix.n, matrix.m);

            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    long intValue = decimal.ToInt64(matrix[i, j]);
                    long resultValue = intValue >> shift;
                    result[i, j] = decimal.FromOACurrency(resultValue);
                }
            }

            return result;
        }

        public static DecimalMatrix operator <<(DecimalMatrix matrix, int shift)
        {
            DecimalMatrix result = new DecimalMatrix(matrix.n, matrix.m);

            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    long intValue = decimal.ToInt64(matrix[i, j]);
                    long resultValue = intValue << shift;
                    result[i, j] = decimal.FromOACurrency(resultValue);
                }
            }

            return result;
        }

        public static bool operator ==(DecimalMatrix matrix1, DecimalMatrix matrix2)
        {
            if (ReferenceEquals(matrix1, matrix2))
            {
                return true;
            }

            if (matrix1 is null || matrix2 is null)
            {
                return false;
            }

            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            {
                return false;
            }

            for (uint i = 0; i < matrix1.n; i++)
            {
                for (uint j = 0; j < matrix1.m; j++)
                {
                    if (matrix1[i, j] != matrix2[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool operator !=(DecimalMatrix matrix1, DecimalMatrix matrix2)
        {
            return !(matrix1 == matrix2);
        }

        public static bool operator >(DecimalMatrix matrix1, DecimalMatrix matrix2)
        {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            {
                return false;
            }

            for (uint i = 0; i < matrix1.n; i++)
            {
                for (uint j = 0; j < matrix1.m; j++)
                {
                    if (matrix1[i, j] <= matrix2[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool operator >=(DecimalMatrix matrix1, DecimalMatrix matrix2)
        {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            {
                return false;
            }

            for (uint i = 0; i < matrix1.n; i++)
            {
                for (uint j = 0; j < matrix1.m; j++)
                {
                    if (matrix1[i, j] < matrix2[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool operator <(DecimalMatrix matrix1, DecimalMatrix matrix2)
        {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            {
                return false;
            }

            for (uint i = 0; i < matrix1.n; i++)
            {
                for (uint j = 0; j < matrix1.m; j++)
                {
                    if (matrix1[i, j] >= matrix2[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool operator <=(DecimalMatrix matrix1, DecimalMatrix matrix2)
        {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            {
                return false;
            }

            for (uint i = 0; i < matrix1.n; i++)
            {
                for (uint j = 0; j < matrix1.m; j++)
                {
                    if (matrix1[i, j] > matrix2[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static DecimalMatrix Inverse(DecimalMatrix matrix)
        {
            Console.WriteLine("Inverse not implemented. Returning the original matrix.");
            return matrix;
        }
    }

    public static void task3()
    {
        DecimalMatrix matrix = new DecimalMatrix(2, 3, 3);
        Console.WriteLine("Size of matrix: {0}x{1}", matrix.Dimensions[0], matrix.Dimensions[1]);
        Console.WriteLine("Element of matrix:");
        matrix.DisplayElements();

        matrix[0, 1] = 10;
        Console.WriteLine("\nMatrix after change [0, 1]:");
        matrix.DisplayElements();

        Console.WriteLine("\nChange all elements to 8:");
        matrix.Assign(8);
        matrix.DisplayElements();

        Console.WriteLine("\nEnter new element:");
        matrix.InputElements();
        Console.WriteLine("\nElement after change:");
        matrix.DisplayElements();

        Console.WriteLine("\nThe number of matrix: {0}", DecimalMatrix.CountMatrices());

        DecimalMatrix matrix1 = new DecimalMatrix(2, 3, 7);
        Console.WriteLine("Matrix1 elements:");
        matrix1.DisplayElements();

        DecimalMatrix matrix2 = new DecimalMatrix(2, 3, 1);
        Console.WriteLine("\nMatrix2 elements:");
        matrix2.DisplayElements();


        Console.WriteLine("Size of matrix1: {0}x{1}", matrix1.Dimensions[0], matrix1.Dimensions[1]);
        Console.WriteLine("Size of matrix2: {0}x{1}", matrix2.Dimensions[0], matrix2.Dimensions[1]);


        DecimalMatrix matrixSum = matrix1 + matrix2;
        if (matrixSum != null)
        {
            Console.WriteLine("\nSum of matrices:");
            matrixSum.DisplayElements();
        }

        DecimalMatrix matrixScalarSum = matrix1 + 10;
        Console.WriteLine("\nSum of matrix1 and scalar:");
        matrixScalarSum.DisplayElements();

        DecimalMatrix matrixDiff = matrix1 - matrix2;
        if (matrixDiff != null)
        {
            Console.WriteLine("\nDifference of matrices:");
            matrixDiff.DisplayElements();
        }

        DecimalMatrix matrixScalarDiff = matrix1 - 5;
        Console.WriteLine("\nDifference of matrix1 and scalar:");
        matrixScalarDiff.DisplayElements();

        DecimalMatrix matrixProduct = matrix1 * matrix2;
        if (matrixProduct != null)
        {
            Console.WriteLine("\nElement-wise multiplication of matrices:");
            matrixProduct.DisplayElements();
        }

        DecimalMatrix matrixScalarProduct = matrix1 * 2;
        Console.WriteLine("\nMultiplication of matrix1 by scalar:");
        matrixScalarProduct.DisplayElements();

        DecimalMatrix matrixDivision = matrix1 / matrix2;
        if (matrixDivision != null)
        {
            Console.WriteLine("\nElement-wise division of matrices:");
            matrixDivision.DisplayElements();
        }

        DecimalMatrix matrixScalarDivision = matrix1 / 2;
        Console.WriteLine("\nDivision of matrix1 by scalar:");
        matrixScalarDivision.DisplayElements();

        DecimalMatrix matrixRemainder = matrix1 % matrix2;
        if (matrixRemainder != null)
        {
            Console.WriteLine("\nElement-wise remainder of matrices:");
            matrixRemainder.DisplayElements();
        }

        DecimalMatrix matrixScalarRemainder = matrix1 % 3;
        Console.WriteLine("\nRemainder of matrix1 by scalar:");
        matrixScalarRemainder.DisplayElements();

        Console.WriteLine("\nBitwise OR operation between matrix1 and matrix2:");
        DecimalMatrix bitwiseOR = matrix1 | matrix2;
        bitwiseOR.DisplayElements();

        Console.WriteLine("\nBitwise OR operation between matrix1 and scalar:");
        DecimalMatrix bitwiseORScalar = matrix1 | 5;
        bitwiseORScalar.DisplayElements();

        Console.WriteLine("\nBitwise XOR operation between matrix1 and matrix2:");
        DecimalMatrix bitwiseXOR = matrix1 ^ matrix2;
        bitwiseXOR.DisplayElements();

        Console.WriteLine("\nBitwise XOR operation between matrix1 and scalar:");
        DecimalMatrix bitwiseXORScalar = matrix1 ^ 5;
        bitwiseXORScalar.DisplayElements();

        Console.WriteLine("\nBitwise AND operation between matrix1 and matrix2:");
        DecimalMatrix bitwiseAND = matrix1 & matrix2;
        bitwiseAND.DisplayElements();

        Console.WriteLine("\nBitwise AND operation between matrix1 and scalar:");
        DecimalMatrix bitwiseANDScalar = matrix1 & 5;
        bitwiseANDScalar.DisplayElements();

        Console.WriteLine("\nBitwise right shift operation of matrix1 by 2 bits:");
        DecimalMatrix rightShift = matrix1 >> 2;
        rightShift.DisplayElements();

        Console.WriteLine("\nBitwise left shift operation of matrix1 by 2 bits:");
        DecimalMatrix leftShift = matrix1 << 2;
        leftShift.DisplayElements();

        Console.WriteLine("\nEquality check between matrix1 and matrix2:");
        Console.WriteLine(matrix1 == matrix2);

        Console.WriteLine("\nInequality check between matrix1 and matrix2:");
        Console.WriteLine(matrix1 != matrix2);

        Console.WriteLine("\nComparison: matrix1 greater than matrix2:");
        Console.WriteLine(matrix1 > matrix2);

        Console.WriteLine("\nComparison: matrix1 greater than or equal to matrix2:");
        Console.WriteLine(matrix1 >= matrix2);

        Console.WriteLine("\nComparison: matrix1 less than matrix2:");
        Console.WriteLine(matrix1 < matrix2);

        Console.WriteLine("\nComparison: matrix1 less than or equal to matrix2:");
        Console.WriteLine(matrix1 <= matrix2);

        Console.WriteLine("\nThe number of matrices: {0}", DecimalMatrix.CountMatrices());
    }
}


