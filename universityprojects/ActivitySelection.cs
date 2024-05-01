public class ActivitySelection
{
    public class Activity
    {
        public int Start { get; set; }
        public int Finish { get; set; }
    }

    public static List<int> SelectActivities(List<Activity> activities)
    {
        activities.Sort((a, b) => a.Finish.CompareTo(b.Finish));

        List<int> selectedActivities = new List<int> { 0 };

        int i = 0;
        for (int j = 1; j < activities.Count; j++)
        {
            if (activities[j].Start >= activities[i].Finish)
            {
                selectedActivities.Add(j);
                i = j;
            }
        }

        return selectedActivities;
    }
}