public class MatrixChainMultiplication
{
    public static int MinMult(int n, int[] d, out int[,] P)
    {
        int[,] M = new int[n + 1, n + 1];
        P = new int[n + 1, n + 1];

        for (int t = 1; t <= n - 1; t++)
        {
            for (int i = 1; i <= n - t; i++)
            {
                int j = i + t;
                M[i, j] = int.MaxValue;

                for (int k = i; k <= j - 1; k++)
                {
                    int cost = M[i, k] + M[k + 1, j] + d[i - 1] * d[k] * d[j];
                    if (cost < M[i, j])
                    {
                        M[i, j] = cost;
                        P[i, j] = k;
                    }
                }
            }
        }

        return M[1, n];
    }
}