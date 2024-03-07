using System;

using System;

public class Triangle {
    private int a, b, c;
    private string color;

    public Triangle(int f, int s, int t) {
        a = f;
        b = s;
        c = t;
        color = "none";
    }

    public Triangle(int f, int s, int t, string col) {
        a = f;
        b = s;
        c = t;
        color = col;
    }

    public void Print() {
        Console.WriteLine($"Triangle lines: a = {a}, b = {b}, c = {c}, color = {color}");
    }

    public int First {
        get { return a; }
        set { a = value; }
    }

    public int Second {
        get { return b; }
        set { b = value; }
    }

    public int Third {
        get { return c; }
        set { c = value; }
    }

    public string Color {
        get { return color; }
    }

    public int Perimeter() {
        return a + b + c;
    }

    public double Area() {
        float halfperimeter = (a + b + c) / 2;
        return Math.Sqrt(halfperimeter * (halfperimeter - a) * (halfperimeter - b) * (halfperimeter - c));
    }

    public int this[int index] {
        get {
            switch (index) {
                case 0: return a;
                case 1: return b;
                case 2: return c;
                default: throw new IndexOutOfRangeException("Index out of range.");
            }
        }
        set {
            switch (index) {
                case 0: a = value; break;
                case 1: b = value; break;
                case 2: c = value; break;
                case 3: color = value.ToString(); break;
                default: throw new IndexOutOfRangeException("Index out of range.");
            }
        }
    }

    public static Triangle operator ++(Triangle triangle) {
        triangle.a++;
        triangle.b++;
        triangle.c++;
        return triangle;
    }

    public static Triangle operator --(Triangle triangle) {
        triangle.a--;
        triangle.b--;
        triangle.c--;
        return triangle;
    }

    public static bool operator true(Triangle triangle) {
        return triangle.a + triangle.b > triangle.c && triangle.a + triangle.c > triangle.b && triangle.b + triangle.c > triangle.a;
    }

    public static bool operator false(Triangle triangle) {
    return triangle.a + triangle.b <= triangle.c || 
           triangle.a + triangle.c <= triangle.b || 
           triangle.b + triangle.c <= triangle.a;
    }

    public static Triangle operator *(Triangle triangle, int scalar) {
        triangle.a *= scalar;
        triangle.b *= scalar;
        triangle.c *= scalar;
        return triangle;
    }

    public static implicit operator string(Triangle triangle) {
        return $"Triangle lines: a = {triangle.a}, b = {triangle.b}, c = {triangle.c}, color = {triangle.color}";
    }
}


public class VectorUInt {
    protected uint[] IntArray; 
    protected uint size; 
    protected int codeError; 
    protected static uint num_vec;

    public VectorUInt() {
        size = 1;
        IntArray = new uint[size];
        num_vec++;
    }

    public VectorUInt(uint vectorSize) {
        size = vectorSize;
        IntArray = new uint[size];
        num_vec++;
    }

    public VectorUInt(uint vectorSize, uint initialValue) {
        size = vectorSize;
        IntArray = new uint[size];
        for (int i = 0; i < size; i++) {
            IntArray[i] = initialValue;
        }
        num_vec++;
    }

    ~VectorUInt() {
        Console.WriteLine("Destructor called");
    }

    public void Input() {
        for (int i = 0; i < size; i++) {
            Console.Write($"Enter element {i}: ");
            IntArray[i] = Convert.ToUInt32(Console.ReadLine());
        }
    }

    public void Display() {
        Console.Write("Vector elements: ");
        for (int i = 0; i < size; i++) {
            Console.Write($"{IntArray[i]} ");
        }
        Console.WriteLine();
    }

    public void SetValue(uint value) {
        for (int i = 0; i < size; i++) {
            IntArray[i] = value;
        }
    }

    public static uint CountVectors() {
        return num_vec;
    }

    public uint Size {
        get { return size; }
    }

    public int CodeError {
        get { return codeError; }
        set { codeError = value; }
    }

    public uint this[int index] {
        get {
            if (index >= 0 && index < size)
                return IntArray[index];
            else {
                codeError = -1;
                return 0;
            }
        }
        set {
            if (index >= 0 && index < size)
                IntArray[index] = value;
            else
                codeError = -1;
        }
    }

    public static bool operator true(VectorUInt vector) {
        foreach (uint element in vector.IntArray) {
            if (element == 0)
                return false;
        }
        return true;
    }

    public static bool operator false(VectorUInt vector) {
        return vector.size == 0 || !vector;
    }

    public static bool operator !(VectorUInt vector) {
        return vector.size != 0;
    }

    public static VectorUInt operator ++(VectorUInt vector) {
        for (int i = 0; i < vector.size; i++) {
            vector.IntArray[i]++;
        }
        return vector;
    }

    public static VectorUInt operator --(VectorUInt vector) {
        for (int i = 0; i < vector.size; i++) {
            vector.IntArray[i]--;
        }
        return vector;
    }

    public static VectorUInt operator +(VectorUInt vector1, VectorUInt vector2) {
        if (vector1.size != vector2.size)
            throw new ArgumentException("Vectors must have the same size.");
        
        VectorUInt result = new VectorUInt(vector1.size);
        for (int i = 0; i < vector1.size; i++) {
            result[i] = vector1[i] + vector2[i];
        }
        return result;
    }

    public static VectorUInt operator -(VectorUInt vector1, VectorUInt vector2) {
        if (vector1.size != vector2.size)
            throw new ArgumentException("Vectors must have the same size.");
        
        VectorUInt result = new VectorUInt(vector1.size);
        for (int i = 0; i < vector1.size; i++) {
            result[i] = vector1[i] - vector2[i];
        }
        return result;
    }

    public static VectorUInt operator *(VectorUInt vector, int scalar) {
        VectorUInt result = new VectorUInt(vector.size);
        for (int i = 0; i < vector.size; i++) {
            result[i] = vector[i] * (uint)scalar;
        }
        return result;
    }

    public static VectorUInt operator /(VectorUInt vector, short scalar) {
        VectorUInt result = new VectorUInt(vector.size);
        for (int i = 0; i < vector.size; i++) {
            result[i] = vector[i] / (uint)scalar;
        }
        return result;
    }

    public static VectorUInt operator %(VectorUInt vector, short scalar) {
        VectorUInt result = new VectorUInt(vector.size);
        for (int i = 0; i < vector.size; i++) {
            result[i] = vector[i] % (uint)scalar;
        }
        return result;
    }

    public static VectorUInt operator |(VectorUInt vector1, VectorUInt vector2) {
        if (vector1.size != vector2.size)
            throw new ArgumentException("Vectors must have the same size.");
        
        VectorUInt result = new VectorUInt(vector1.size);
        for (int i = 0; i < vector1.size; i++) {
            result[i] = vector1[i] | vector2[i];
        }
        return result;
    }

    public static VectorUInt operator &(VectorUInt vector1, VectorUInt vector2) {
        if (vector1.size != vector2.size)
            throw new ArgumentException("Vectors must have the same size.");
        
        VectorUInt result = new VectorUInt(vector1.size);
        for (int i = 0; i < vector1.size; i++) {
            result[i] = vector1[i] & vector2[i];
        }
        return result;
    }

    public static VectorUInt operator ~(VectorUInt vector) {
        VectorUInt result = new VectorUInt(vector.size);
        for (int i = 0; i < vector.size; i++) {
            result[i] = ~vector[i];
        }
        return result;
    }

    public static bool operator ==(VectorUInt vector1, VectorUInt vector2) {
        return vector1.Equals(vector2);
    }

    public static bool operator !=(VectorUInt vector1, VectorUInt vector2) {
        return !vector1.Equals(vector2);
    }

    public static bool operator >(VectorUInt vector1, VectorUInt vector2) {
        if (vector1.size != vector2.size)
            throw new ArgumentException("Vectors must have the same size.");
        
        for (int i = 0; i < vector1.size; i++) {
            if (vector1[i] <= vector2[i])
                return false;
        }
        return true;
    }

    public static bool operator <(VectorUInt vector1, VectorUInt vector2) {
        if (vector1.size != vector2.size)
            throw new ArgumentException("Vectors must have the same size.");
        
        for (int i = 0; i < vector1.size; i++) {
            if (vector1[i] >= vector2[i])
                return false;
        }
        return true;
    }

    public static bool operator >=(VectorUInt vector1, VectorUInt vector2) {
        return vector1 == vector2 || vector1 > vector2;
    }

    public static bool operator <=(VectorUInt vector1, VectorUInt vector2) {
        return vector1 == vector2 || vector1 < vector2;
    }
}

public class MatrixUint {
    protected uint[,] IntArray; // масив
    protected int n, m; // розміри матриці
    protected int codeError; // код помилки
    protected static int num_m; // кількість матриць

    public MatrixUint() {
        n = 1;
        m = 1;
        IntArray = new uint[n, m];
        num_m++;
    }

    public MatrixUint(int rows, int columns) {
        n = rows;
        m = columns;
        IntArray = new uint[n, m];
        num_m++;
    }

    public MatrixUint(int rows, int columns, uint initialValue) {
        n = rows;
        m = columns;
        IntArray = new uint[n, m];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                IntArray[i, j] = initialValue;
            }
        }
        num_m++;
    }

    ~MatrixUint() {
        Console.WriteLine("Destructor called");
    }

    public void Input() {
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                Console.Write($"Enter element at position ({i},{j}): ");
                IntArray[i, j] = Convert.ToUInt32(Console.ReadLine());
            }
        }
    }

    public void Display() {
        Console.WriteLine("Matrix elements:");
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                Console.Write($"{IntArray[i, j]} ");
            }
            Console.WriteLine();
        }
    }

    public void SetValue(uint value) {
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                IntArray[i, j] = value;
            }
        }
    }

    public static int CountMatrices() {
        return num_m;
    }

    public int Rows {
        get { return n; }
    }

    public int Columns {
        get { return m; }
    }

    public int CodeError {
        get { return codeError; }
        set { codeError = value; }
    }

    public uint this[int i, int j] {
        get {
            if (i >= 0 && i < n && j >= 0 && j < m)
                return IntArray[i, j];
            else {
                codeError = -1;
                return 0;
            }
        }
        set {
            if (i >= 0 && i < n && j >= 0 && j < m)
                IntArray[i, j] = value;
            else
                codeError = -1;
        }
    }

    public uint this[int k] {
        get {
            if (k >= 0 && k < n * m)
                return IntArray[k / m, k % m];
            else {
                codeError = -1;
                return 0;
            }
        }
        set {
            if (k >= 0 && k < n * m)
                IntArray[k / m, k % m] = value;
            else
                codeError = -1;
        }
    }

    public static bool operator true(MatrixUint matrix) {
        foreach (uint element in matrix.IntArray) {
            if (element == 0)
                return false;
        }
        return true;
    }

    public static bool operator false(MatrixUint matrix) {
        return matrix.n == 0 || matrix.m == 0 || !matrix;
    }

    public static bool operator !(MatrixUint matrix) {
        return matrix.n != 0 || matrix.m != 0;
    }

    public static MatrixUint operator ++(MatrixUint matrix) {
        for (int i = 0; i < matrix.n; i++) {
            for (int j = 0; j < matrix.m; j++) {
                matrix.IntArray[i, j]++;
            }
        }
        return matrix;
    }

    public static MatrixUint operator --(MatrixUint matrix) {
        for (int i = 0; i < matrix.n; i++) {
            for (int j = 0; j < matrix.m; j++) {
                matrix.IntArray[i, j]--;
            }
        }
        return matrix;
    }

    public static MatrixUint operator +(MatrixUint matrix1, MatrixUint matrix2) {
        if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            throw new ArgumentException("Matrices must have the same dimensions.");
        
        MatrixUint result = new MatrixUint(matrix1.n, matrix1.m);
        for (int i = 0; i < matrix1.n; i++) {
            for (int j = 0; j < matrix1.m; j++) {
                result[i, j] = matrix1[i, j] + matrix2[i, j];
            }
        }
        return result;
    }

    public static MatrixUint operator -(MatrixUint matrix1, MatrixUint matrix2) {
        if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            throw new ArgumentException("Matrices must have the same dimensions.");
        
        MatrixUint result = new MatrixUint(matrix1.n, matrix1.m);
        for (int i = 0; i < matrix1.n; i++) {
            for (int j = 0; j < matrix1.m; j++) {
                result[i, j] = matrix1[i, j] - matrix2[i, j];
            }
        }
        return result;
    }

    public static MatrixUint operator *(MatrixUint matrix1, MatrixUint matrix2) {
        if (matrix1.m != matrix2.n)
            throw new ArgumentException("Number of columns in the first matrix must equal the number of rows in the second matrix.");
        
        MatrixUint result = new MatrixUint(matrix1.n, matrix2.m);
        for (int i = 0; i < matrix1.n; i++) {
            for (int j = 0; j < matrix2.m; j++) {
                uint sum = 0;
                for (int k = 0; k < matrix1.m; k++) {
                    sum += matrix1[i, k] * matrix2[k, j];
                }
                result[i, j] = sum;
            }
        }
        return result;
    }

    public static MatrixUint operator *(MatrixUint matrix, uint scalar) {
        MatrixUint result = new MatrixUint(matrix.n, matrix.m);
        for (int i = 0; i < matrix.n; i++) {
            for (int j = 0; j < matrix.m; j++) {
                result[i, j] = matrix[i, j] * scalar;
            }
        }
        return result;
    }

    public static MatrixUint operator /(MatrixUint matrix, uint scalar) {
        MatrixUint result = new MatrixUint(matrix.n, matrix.m);
        for (int i = 0; i < matrix.n; i++) {
            for (int j = 0; j < matrix.m; j++) {
                result[i, j] = matrix[i, j] / scalar;
            }
        }
        return result;
    }

    public static MatrixUint operator %(MatrixUint matrix, uint scalar) {
        MatrixUint result = new MatrixUint(matrix.n, matrix.m);
        for (int i = 0; i < matrix.n; i++) {
            for (int j = 0; j < matrix.m; j++) {
                result[i, j] = matrix[i, j] % scalar;
            }
        }
        return result;
    }

    public static MatrixUint operator |(MatrixUint matrix1, MatrixUint matrix2) {
        if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            throw new ArgumentException("Matrices must have the same dimensions.");
        
        MatrixUint result = new MatrixUint(matrix1.n, matrix1.m);
        for (int i = 0; i < matrix1.n; i++) {
            for (int j = 0; j < matrix1.m; j++) {
                result[i, j] = matrix1[i, j] | matrix2[i, j];
            }
        }
        return result;
    }

    public static MatrixUint operator ^(MatrixUint matrix1, MatrixUint matrix2) {
        if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            throw new ArgumentException("Matrices must have the same dimensions.");
        
        MatrixUint result = new MatrixUint(matrix1.n, matrix1.m);
        for (int i = 0; i < matrix1.n; i++) {
            for (int j = 0; j < matrix1.m; j++) {
                result[i, j] = matrix1[i, j] ^ matrix2[i, j];
            }
        }
        return result;
    }

    public static MatrixUint operator &(MatrixUint matrix1, MatrixUint matrix2) {
        if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            throw new ArgumentException("Matrices must have the same dimensions.");
        
        MatrixUint result = new MatrixUint(matrix1.n, matrix1.m);
        for (int i = 0; i < matrix1.n; i++) {
            for (int j = 0; j < matrix1.m; j++) {
                result[i, j] = matrix1[i, j] & matrix2[i, j];
            }
        }
        return result;
    }

    public static MatrixUint operator >>(MatrixUint matrix, int shift) {
        MatrixUint result = new MatrixUint(matrix.n, matrix.m);
        for (int i = 0; i < matrix.n; i++) {
            for (int j = 0; j < matrix.m; j++) {
                result[i, j] = matrix[i, j] >> shift;
            }
        }
        return result;
    }

    public static MatrixUint operator <<(MatrixUint matrix, int shift) {
        MatrixUint result = new MatrixUint(matrix.n, matrix.m);
        for (int i = 0; i < matrix.n; i++) {
            for (int j = 0; j < matrix.m; j++) {
                result[i, j] = matrix[i, j] << shift;
            }
        }
        return result;
    }

    public static bool operator ==(MatrixUint matrix1, MatrixUint matrix2) {
        if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            return false;

        for (int i = 0; i < matrix1.n; i++) {
            for (int j = 0; j < matrix1.m; j++) {
                if (matrix1[i, j] != matrix2[i, j])
                    return false;
            }
        }
        return true;
    }

    public static bool operator !=(MatrixUint matrix1, MatrixUint matrix2) {
        return !(matrix1 == matrix2);
    }

    public static bool operator >(MatrixUint matrix1, MatrixUint matrix2) {
        if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            throw new ArgumentException("Matrices must have the same dimensions.");

        for (int i = 0; i < matrix1.n; i++) {
            for (int j = 0; j < matrix1.m; j++) {
                if (matrix1[i, j] <= matrix2[i, j])
                    return false;
            }
        }
        return true;
    }

    public static bool operator <(MatrixUint matrix1, MatrixUint matrix2) {
        if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            throw new ArgumentException("Matrices must have the same dimensions.");

        for (int i = 0; i < matrix1.n; i++) {
            for (int j = 0; j < matrix1.m; j++) {
                if (matrix1[i, j] >= matrix2[i, j])
                    return false;
            }
        }
        return true;
    }

    public static bool operator >=(MatrixUint matrix1, MatrixUint matrix2) {
        return matrix1 == matrix2 || matrix1 > matrix2;
    }

    public static bool operator <=(MatrixUint matrix1, MatrixUint matrix2) {
        return matrix1 == matrix2 || matrix1 < matrix2;
    }
}


class Task
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the task");
            string? str = Console.ReadLine();
            int n = 0; 
            if (str != null) n = int.Parse(str);
            if (n == 1) {
                Triangle triangle1 = new Triangle(3, 4, 5);
                Console.WriteLine($"Perimeter: {triangle1.Perimeter()}");
                Console.WriteLine($"Area of triangle: {triangle1.Area()}");
                if (triangle1) {
                    Console.WriteLine("Triangle is real");
                } else {
                    Console.WriteLine("Triangle is not real");
                }
                triangle1 *= 2;
                triangle1.Print();

            } else if(n == 2) {
                VectorUInt vector1 = new VectorUInt(4, 4);
                VectorUInt vector2 = new VectorUInt(4, 3);
                if (vector1 == vector2) {
                    Console.WriteLine("The vectors is the same");
                } else {
                    Console.WriteLine("The vectors is diferent");
                }
                vector1.Display();
                vector1++;
                vector1.Display();
                vector1 += vector2;
                vector1.Display();
                vector1--;
                vector1.Display();
            } else {
                MatrixUint matrix1 = new MatrixUint(3, 3, 1);

                Console.WriteLine("Matrix 1:");
                matrix1.Display();

                MatrixUint matrix2 = new MatrixUint(3, 3, 2);

                Console.WriteLine("\nMatrix 2:");
                matrix2.Display();

                MatrixUint sumMatrix = matrix1 + matrix2;
                Console.WriteLine("\nSum of matrices:");
                sumMatrix.Display();

                MatrixUint productMatrix = matrix1 * matrix2;
                Console.WriteLine("\n Multiply of matrices:");
                productMatrix.Display();

                if (matrix1 == matrix2)
                {
                Console.WriteLine("\nMatrix 1 is equal to Matrix 2");
                } else {
                Console.WriteLine("\nMatrix 1 is not equal to Matrix 2");
                }
            }
            
        }
    }