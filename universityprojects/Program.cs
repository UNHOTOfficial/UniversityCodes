class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Select an algorithm:");
        Console.WriteLine("1. Insertion Sort");
        Console.WriteLine("2. Recursive Fibonacci");
        Console.WriteLine("3. Binary Search");
        Console.WriteLine("4. Merge Sort");
        Console.WriteLine("5. Strassen");
        Console.WriteLine("6. Two Big Number Multiplication");
        Console.WriteLine("7. Randomized Select");

        int selection = Convert.ToInt32(Console.ReadLine());

        switch (selection)
        {
            case 1:
                Console.WriteLine("Enter a list of numbers separated by space:");

                // read inputs and call the InsertionSort.Sort function
                int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                // call the Sort function from InsertionSort.cs
                InsertionSort.Sort(array);

                // print the sorted array
                Console.WriteLine("Sorted array: " + string.Join(" ", array));
                break;


            case 2:
                Console.WriteLine("Enter a number for Fibonacci calculation:");

                // read input
                int n = Convert.ToInt32(Console.ReadLine());

                //  call the Fibonacci function from FiboRecursive.cs
                int fiboResult = FiboRecursive.Fibonacci(n);

                // print the result
                Console.WriteLine($"Fibonacci of {n}: {fiboResult}");
                break;

            case 3:
                Console.WriteLine("Enter a sorted list of numbers separated by space:");

                // read inputs
                int[] array1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                Console.WriteLine("Enter a number to search for:");

                // read the target number
                int target = Convert.ToInt32(Console.ReadLine());

                // call the Search function
                int index = BinarySearch.Search(array1, target);

                // print the result
                if (index != -1)
                {
                    // print the index of the target number
                    Console.WriteLine($"Found {target} at index {index}.");
                }
                else
                {
                    // print that the target number is not found in the array
                    Console.WriteLine($"{target} not found in the array.");
                }
                break;

            case 4:
                Console.WriteLine("Enter a list of numbers separated by space:");

                // read inputs
                int[] array2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                // call the Sort function from MergeSort.cs
                MergeSort.Sort(array2, 0, array2.Length - 1);

                // print the sorted array
                Console.WriteLine("Sorted array: " + string.Join(" ", array2));
                break;

            case 5:
                Console.WriteLine("Enter the size of the matrices (size):");
                int size = Convert.ToInt32(Console.ReadLine());

                // read the elements of the first matrices
                Console.WriteLine("Enter the elements of the first matrix separated by space:");
                int[,] matrix1 = new int[size, size];
                for (int i = 0; i < size; i++)
                {
                    int[] row = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                    for (int j = 0; j < size; j++)
                    {
                        matrix1[i, j] = row[j];
                    }
                }

                // read the elements of the second matrix
                Console.WriteLine("Enter the elements of the second matrix separated by space:");
                int[,] matrix2 = new int[size, size];
                for (int i = 0; i < size; i++)
                {
                    int[] row = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                    for (int j = 0; j < size; j++)
                    {
                        matrix2[i, j] = row[j];
                    }
                }

                // call the Multiply function from Strassen.cs
                int[,] result = Strassen.Multiply(matrix1, matrix2);

                // print the resulting matrix
                Console.WriteLine("Resulting matrix: ");
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        Console.Write(result[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                break;

            case 6:
                Console.WriteLine("Enter the first big number:");
                dynamic num1 = Console.ReadLine();
                Console.WriteLine("Enter the second big number:");
                dynamic num2 = Console.ReadLine();
                dynamic result1 = BigNumberMultiplication.Multiply(num1, num2);
                Console.WriteLine("Resulting big number: " + result1);
                break;

            case 7:
               // selection
                break;

            default:
                Console.WriteLine("Invalid selection.");
                break;
        }
    }
}