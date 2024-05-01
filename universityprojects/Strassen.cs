public class Strassen
{
    public static int[,] Multiply(int[,] a, int[,] b)
    {
        int n = a.GetLength(0);
        int[,] result = new int[n, n];

        if (n == 1)
        {
            result[0, 0] = a[0, 0] * b[0, 0];
        }
        else
        {
            int[,] a11, a12, a21, a22, b11, b12, b21, b22;
            int[,] c11, c12, c21, c22;
            int[,] p1, p2, p3, p4, p5, p6, p7;

            int newSize = n / 2;
            a11 = new int[newSize, newSize];
            a12 = new int[newSize, newSize];
            a21 = new int[newSize, newSize];
            a22 = new int[newSize, newSize];

            b11 = new int[newSize, newSize];
            b12 = new int[newSize, newSize];
            b21 = new int[newSize, newSize];
            b22 = new int[newSize, newSize];

            Split(a, a11, 0, 0);
            Split(a, a12, 0, newSize);
            Split(a, a21, newSize, 0);
            Split(a, a22, newSize, newSize);

            Split(b, b11, 0, 0);
            Split(b, b12, 0, newSize);
            Split(b, b21, newSize, 0);
            Split(b, b22, newSize, newSize);

            p1 = Multiply(Add(a11, a22), Add(b11, b22));
            p2 = Multiply(Add(a21, a22), b11);
            p3 = Multiply(a11, Subtract(b12, b22));
            p4 = Multiply(a22, Subtract(b21, b11));
            p5 = Multiply(Add(a11, a12), b22);
            p6 = Multiply(Subtract(a21, a11), Add(b11, b12));
            p7 = Multiply(Subtract(a12, a22), Add(b21, b22));

            c12 = Add(p3, p5);
            c21 = Add(p2, p4);

            c11 = Subtract(Add(Add(p1, p4), p7), p5);
            c22 = Subtract(Add(Add(p1, p3), p6), p2);

            Join(c11, result, 0, 0);
            Join(c12, result, 0, newSize);
            Join(c21, result, newSize, 0);
            Join(c22, result, newSize, newSize);
        }

        return result;
    }

    public static int[,] Add(int[,] a, int[,] b)
    {
        int n = a.GetLength(0);
        int[,] result = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                result[i, j] = a[i, j] + b[i, j];
            }
        }
        return result;
    }

    public static int[,] Subtract(int[,] a, int[,] b)
    {
        int n = a.GetLength(0);
        int[,] result = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                result[i, j] = a[i, j] - b[i, j];
            }
        }
        return result;
    }

    public static void Split(int[,] parent, int[,] child, int iB, int jB)
    {
        for (int i1 = 0, i2 = iB; i1 < child.GetLength(0); i1++, i2++)
        {
            for (int j1 = 0, j2 = jB; j1 < child.GetLength(0); j1++, j2++)
            {
                child[i1, j1] = parent[i2, j2];
            }
        }
    }

    public static void Join(int[,] child, int[,] parent, int iB, int jB)
    {
        for (int i1 = 0, i2 = iB; i1 < child.GetLength(0); i1++, i2++)
        {
            for (int j1 = 0, j2 = jB; j1 < child.GetLength(0); j1++, j2++)
            {
                parent[i2, j2] = child[i1, j1];
            }
        }
    }
}