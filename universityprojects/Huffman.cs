public class HuffmanNode
{
    public char Symbol { get; set; }
    public int Frequency { get; set; }
    public HuffmanNode? Left { get; set; }  // Make nullable
    public HuffmanNode? Right { get; set; } // Make nullable
}

public class Huffman
{
    public static HuffmanNode BuildTree(Dictionary<char, int> frequencies)
    {
        // Provide a type for the priority
        PriorityQueue<HuffmanNode, int> queue = new PriorityQueue<HuffmanNode, int>(Comparer<int>.Create((a, b) => a - b));

        foreach (var symbol in frequencies.Keys)
        {
            queue.Enqueue(new HuffmanNode { Symbol = symbol, Frequency = frequencies[symbol] }, frequencies[symbol]);
        }

        // Call the method instead of using it as a property
        while (queue.Count > 1)
        {
            HuffmanNode x = queue.Dequeue();
            HuffmanNode y = queue.Dequeue();

            HuffmanNode z = new HuffmanNode
            {
                Frequency = x.Frequency + y.Frequency,
                Left = x,
                Right = y
            };

            queue.Enqueue(z, z.Frequency);
        }

        return queue.Dequeue();
    }
}