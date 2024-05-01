public class JobScheduler
{
    public class Job
    {
        public int Id { get; set; }
        public int Deadline { get; set; }
    }

    public static List<int> Schedule(int n, int[] deadlines)
    {
        List<Job> jobs = new List<Job>();
        for (int i = 0; i < n; i++)
        {
            jobs.Add(new Job { Id = i + 1, Deadline = deadlines[i] });
        }

        jobs.Sort((a, b) => a.Deadline.CompareTo(b.Deadline));

        List<int> J = new List<int> { jobs[0].Id };

        for (int i = 1; i < n; i++)
        {
            List<int> K = new List<int>(J) { jobs[i].Id };

            if (IsFeasible(K, jobs))
            {
                J = K;
            }
        }

        return J;
    }

    private static bool IsFeasible(List<int> K, List<Job> jobs)
    {
        K.Sort();
        for (int i = 0; i < K.Count; i++)
        {
            if (jobs[K[i] - 1].Deadline < i + 1)
            {
                return false;
            }
        }
        return true;
    }
}