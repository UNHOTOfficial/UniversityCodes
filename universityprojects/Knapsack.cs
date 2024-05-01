public class Item
{
    public int Value { get; set; }
    public int Weight { get; set; }
}

public class FractionalKnapsack
{
    public static double FractionalKnapsackProblem(int capacity, List<Item> items)
    {
        items.Sort((a, b) => (b.Value / (double)b.Weight).CompareTo(a.Value / (double)a.Weight));

        double totalValue = 0;
        int remainingWeight = capacity;

        foreach (var item in items)
        {
            if (item.Weight <= remainingWeight)
            {
                remainingWeight -= item.Weight;
                totalValue += item.Value;
            }
            else
            {
                totalValue += item.Value * ((double)remainingWeight / item.Weight);
                break;
            }
        }

        return totalValue;
    }
}