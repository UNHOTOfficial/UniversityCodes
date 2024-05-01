public class BinomialCoefficient
{
    public static int Bin(int n, int k)
    {
        int[,] B = new int[n + 1, k + 1];

        for (int i = 0; i <= n; i++)
        {
            for (int j = 0; j <= Math.Min(i, k); j++)
            {
                if (j == 0 || j == i)
                    B[i, j] = 1;
                else
                    B[i, j] = B[i - 1, j - 1] + B[i - 1, j];
            }
        }

        return B[n, k];
    }
}