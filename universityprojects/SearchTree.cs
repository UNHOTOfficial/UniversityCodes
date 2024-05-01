public class OptimalSearchTree
{
    public static float OptSearchTree(int n, float[] p, out float minavg, out int[,] R)
    {
        float[,] A = new float[n + 2, n + 1];
        R = new int[n + 2, n + 1];

        for (int i = 1; i <= n; i++)
        {
            A[i, i - 1] = 0;
            A[i, i] = p[i - 1];
            R[i, i] = i;
            R[i, i - 1] = 0;
        }

        A[n + 1, n] = 0;
        R[n + 1, n] = 0;

        for (int t = 1; t <= n - 1; t++)
        {
            for (int i = 1; i <= n - t; i++)
            {
                int j = i + t;
                A[i, j] = float.MaxValue;
                float sum = 0;

                for (int m = i; m <= j; m++)
                    sum += p[m - 1];

                for (int k = i; k <= j; k++)
                {
                    float cost = ((k > i) ? A[i, k - 1] : 0) + ((k < j) ? A[k + 1, j] : 0) + sum;
                    if (cost < A[i, j])
                    {
                        A[i, j] = cost;
                        R[i, j] = k;
                    }
                }
            }
        }

        minavg = A[1, n];
        return minavg;
    }
}