// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


public class Matrix<T>
{
    private T[,] _data;

    public int Rows => _data.GetLength(0); 
    public int Columns => _data.GetLength(1);


    public Matrix(int rows, int columns)
    {
        if (rows <= 0 || columns <= 0)
            throw new ArgumentException("A sorok és oszlopok száma pozitív kell legyen.");
        _data = new T[rows, columns];
    }


    public Matrix(int rows) : this(rows, rows)
    {
    }

    public Matrix() : this(3, 3)
    {
    }

 
    public void Fill(T element)
    {
        for (int i = 0; i < Rows; i++)
            for (int j = 0; j < Columns; j++)
                _data[i, j] = element;
    }

    public (int columns, int rows) GetSize()
    {
        return (Columns, Rows);
    }

 
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
                result._data[i, j] = x + y; 
            }
        }
        return result;
    }
}
