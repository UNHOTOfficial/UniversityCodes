public class QuickSort
{
    public static void Sort(int[] array, int low, int high)
    {
        if (low < high)
        {
            // pi is partitioning index, array[pi] is now at right place
            int pi = Partition(array, low, high);

            // Recursively sort elements before partition and after partition
            Sort(array, low, pi - 1);
            Sort(array, pi + 1, high);
        }
    }

    private static int Partition(int[] array, int low, int high)
    {
        int pivot = array[high];
        int i = (low - 1); // Index of smaller element

        for (int j = low; j <= high - 1; j++)
        {
            // If current element is smaller than or equal to pivot
            if (array[j] <= pivot)
            {
                i++;

                // Swap array[i] and array[j]
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }

        // Swap array[i+1] and array[high] (or pivot)
        int temp1 = array[i + 1];
        array[i + 1] = array[high];
        array[high] = temp1;

        return i + 1;
    }
}