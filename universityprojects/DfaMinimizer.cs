public class DFAMinimizer
{
    private Dictionary<string, Dictionary<string, string>> dfa;
    private List<HashSet<string>> partitions;

    public DFAMinimizer(Dictionary<string, Dictionary<string, string>> dfa)
    {
        this.dfa = dfa;
        this.partitions = new List<HashSet<string>>();
    }

    public Dictionary<string, Dictionary<string, string>> Minimize()
    {
        // Initialize partitions with final and non-final states
        HashSet<string> finalStates = new HashSet<string>(dfa["final_states"].Values);
        HashSet<string> nonFinalStates = new HashSet<string>(dfa.Keys.Except(finalStates));
        partitions.Add(finalStates);
        partitions.Add(nonFinalStates);

        bool changed;
        do
        {
            changed = false;
            for (int i = 0; i < partitions.Count; i++)
            {
                HashSet<string> partition = partitions[i];
                var groups = GroupByTransitions(partition);
                if (groups.Count > 1)
                {
                    partitions.RemoveAt(i);
                    partitions.AddRange(groups);
                    changed = true;
                    break;
                }
            }
        } while (changed);

        return CreateNewDFA();
    }

    private List<HashSet<string>> GroupByTransitions(HashSet<string> states)
    {
        var groups = new Dictionary<string, HashSet<string>>();
        foreach (string state in states)
        {
            string key = string.Join(",", dfa[state].OrderBy(kvp => kvp.Key).Select(kvp => FindPartition(kvp.Value)));
            if (!groups.ContainsKey(key))
            {
                groups[key] = new HashSet<string>();
            }
            groups[key].Add(state);
        }
        return groups.Values.ToList();
    }

    private int FindPartition(string state)
    {
        for (int i = 0; i < partitions.Count; i++)
        {
            if (partitions[i].Contains(state))
            {
                return i;
            }
        }
        return -1;
    }

    private Dictionary<string, Dictionary<string, string>> CreateNewDFA()
    {
        var newDFA = new Dictionary<string, Dictionary<string, string>>();
        foreach (HashSet<string> partition in partitions)
        {
            string representative = partition.First();
            newDFA[representative] = dfa[representative];
        }
        return newDFA;
    }
}