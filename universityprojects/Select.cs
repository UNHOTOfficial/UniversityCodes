public class SelectAlgorithm
{
    public static int Select(int[] A, int p, int r, int i)
    {
        if (p == r)
            return A[p];

        int q = RandomizedPartition(A, p, r);
        int k = q - p + 1;

        if (i == k)
            return A[q];
        else if (i < k)
            return Select(A, p, q - 1, i);
        else
            return Select(A, q + 1, r, i - k);
    }

    private static int RandomizedPartition(int[] A, int p, int r)
    {
        Random rand = new Random();
        int i = rand.Next(p, r);
        Swap(A, r, i);
        return Partition(A, p, r);
    }

    private static int Partition(int[] A, int p, int r)
    {
        int x = A[r];
        int i = p - 1;
        for (int j = p; j <= r - 1; j++)
        {
            if (A[j] <= x)
            {
                i++;
                Swap(A, i, j);
            }
        }
        Swap(A, i + 1, r);
        return i + 1;
    }

    private static void Swap(int[] A, int i, int j)
    {
        int temp = A[i];
        A[i] = A[j];
        A[j] = temp;
    }
}