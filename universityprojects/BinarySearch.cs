// problems
public class BinarySearch
{
    public static int Search(int[] array, int target)
    {

        // Define the left and right pointers
        int left = 0;
        int right = array.Length - 1;

        while (left <= right)
        {
            // Find the middle element
            int mid = left + (right - left) / 2;

            // if the target is found, return the index
            if (array[mid] == target)
            {
                // return the index of the target
                return mid;
            }

            // if the target is greater than the middle element, search the right side of the array
            else if (array[mid] < target)
            {
                // search the right side of the array
                left = mid + 1;
            }

            // if the target is less than the middle element, search the left side of the array
            else
            {
                // search the left side of the array
                right = mid - 1;
            }
        }

        // Return -1 if the target is not found
        return -1;
    }
}