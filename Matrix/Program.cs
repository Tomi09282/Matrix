// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


public class Matrix<T> where T : struct, IComparable, IConvertible, IFormattable
{
    private T[,] _data;

    public int Rows => _data.GetLength(0); // Sorok száma
    public int Columns => _data.GetLength(1); // Oszlopok száma

    // Konstruktor: m*n
    public Matrix(int rows, int columns)
    {
        if (rows <= 0 || columns <= 0)
            throw new ArgumentException("A sorok és oszlopok száma pozitív kell legyen.");
        _data = new T[rows, columns];
    }

    // Konstruktor: n*x
    public Matrix(int rows) : this(rows, rows)
    {
    }

    // Konstruktor: 3x3 alapértelmezett
    public Matrix() : this(3, 3)
    {
    }

    // Fill metódus
    public void Fill(T element)
    {
        for (int i = 0; i < Rows; i++)
            for (int j = 0; j < Columns; j++)
                _data[i, j] = element;
    }

    // Mátrix méret visszaadása
    public (int columns, int rows) GetSize()
    {
        return (Columns, Rows);
    }

    // ToString() felülírás
    public override string ToString()
    {
        var result = "";
        for (int i = 0; i < Rows; i++)
        {
            result += "| ";
            for (int j = 0; j < Columns; j++)
            {
                result += _data[i, j] + (j < Columns - 1 ? " , " : " ");
            }
            result += "|\n";
        }
        return result;
    }

    // Mátrix összeadása
    public static Matrix<T> Add(Matrix<T> a, Matrix<T> b)
    {
        if (a.Rows != b.Rows || a.Columns != b.Columns)
            throw new ArgumentException("A két mátrix mérete nem egyezik meg.");

        var result = new Matrix<T>(a.Rows, a.Columns);
        for (int i = 0; i < a.Rows; i++)
        {
            for (int j = 0; j < a.Columns; j++)
            {
                dynamic x = a._data[i, j];
                dynamic y = b._data[i, j];
                result._data[i, j] = x + y; // Dinamikus típusok összeadása
            }
        }
        return result;
    }

    // RotateX: mátrix forgatása X tengely körül
    public Matrix<T> RotateX()
    {
        var result = new Matrix<T>(Rows, Columns);
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                result._data[Rows - 1 - i, j] = _data[i, j];
            }
        }
        return result;
    }

    // RotateY: mátrix forgatása Y tengely körül
    public Matrix<T> RotateY()
    {
        var result = new Matrix<T>(Rows, Columns);
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                result._data[i, Columns - 1 - j] = _data[i, j];
            }
        }
        return result;
    }
}
