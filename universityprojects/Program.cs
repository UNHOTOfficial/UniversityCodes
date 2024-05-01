class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Select an algorithm:");
        Console.WriteLine("1. Selection Sort");
        Console.WriteLine("2. Job Scheduling");
        Console.WriteLine("3. Activity Selection");
        Console.WriteLine("4. Huffman Coding");
        Console.WriteLine("5. Fractional Knapsack");

        int selection = Convert.ToInt32(Console.ReadLine());

        switch (selection)
        {
            case 1:
                Console.WriteLine("Enter a list of numbers separated by space:");
                int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                SelectionSort.Sort(array);
                Console.WriteLine("Sorted array: " + string.Join(" ", array));
                break;

            case 2:
                Console.WriteLine("Enter the number of jobs:");
                int n = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the deadlines for the jobs separated by space:");
                int[] deadlines = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                List<int> J = JobScheduler.Schedule(n, deadlines);
                Console.WriteLine("Scheduled jobs: " + string.Join(" ", J));
                break;

            case 3:
                // Here you would need to ask the user for the start and finish times of the activities
                // and then call the ActivitySelection.SelectActivities function.
                break;

            case 4:
                Console.WriteLine("Enter a string:");
                string input = Console.ReadLine();
                Dictionary<char, int> frequencies = input.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
                HuffmanNode root = Huffman.BuildTree(frequencies);
                // Here you would need to print the Huffman tree or use it to encode the input string.
                break;

            case 5:
                Console.WriteLine("Enter the capacity of the knapsack:");
                int capacity = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the values and weights of the items separated by space (value1 weight1 value2 weight2 ...):");
                int[] valuesAndWeights = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                List<Item> items = new List<Item>();
                for (int i = 0; i < valuesAndWeights.Length; i += 2)
                {
                    items.Add(new Item { Value = valuesAndWeights[i], Weight = valuesAndWeights[i + 1] });
                }
                double maxValue = FractionalKnapsack.FractionalKnapsackProblem(capacity, items);
                Console.WriteLine("Maximum value: " + maxValue);
                break;

            default:
                Console.WriteLine("Invalid selection.");
                break;
        }
    }
}