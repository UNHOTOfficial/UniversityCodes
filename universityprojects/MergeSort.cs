// problems
public class MergeSort
{
    public static void Sort(int[] array, int left, int right)
    {
        // Check if the left index is less than the right index
        if (left < right)
        {
            // Find the middle point
            int middle = left + (right - left) / 2;

            // Sort first and second halves
            Sort(array, left, middle);
            Sort(array, middle + 1, right);

            // Merge the sorted halves
            Merge(array, left, middle, right);
        }
    }

    private static void Merge(int[] array, int left, int middle, int right)
    {
        int i, j, k;
        int n1 = middle - left + 1;
        int n2 = right - middle;

        // Create temp arrays
        int[] leftArray = new int[n1];
        int[] rightArray = new int[n2];

        // Copy data to temp arrays
        for (i = 0; i < n1; i++)
            leftArray[i] = array[left + i];
        for (j = 0; j < n2; j++)
            rightArray[j] = array[middle + 1 + j];

        // Merge the temp arrays back into array[left..right]
        i = 0;
        j = 0;
        k = left;
        while (i < n1 && j < n2)
        {
            if (leftArray[i] <= rightArray[j])
            {
                array[k] = leftArray[i];
                i++;
            }
            else
            {
                array[k] = rightArray[j];
                j++;
            }
            k++;
        }

        // Copy the remaining elements of leftArray[], if there are any
        while (i < n1)
        {
            array[k] = leftArray[i];
            i++;
            k++;
        }

        // Copy the remaining elements of rightArray[], if there are any
        while (j < n2)
        {
            array[k] = rightArray[j];
            j++;
            k++;
        }
    }
}