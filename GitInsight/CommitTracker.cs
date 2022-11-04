namespace GitInsight;

public class CommitTracker
{
    GitInsightRepository _repository;
    public CommitTracker(GitInsightRepository insightRepository)
    {
        _repository = insightRepository;
    }



    /// <summary>
    /// This method returns a formatted string of commits per day, optionally only by a single author
    /// </summary>
    /// <param name="path">path to a local git repository</param>
    /// <param name="author">optional: only get commits by author</param>
    public IEnumerable<(DateTime, int)> getCommitsPerDay(string author = "")
    {
        IDictionary<DateTime, int> commitsPerDay = new Dictionary<DateTime, int>();
        foreach (var commit in _repository.Commits)
        {
            if (author != "" && author != commit.Author.Name)
            {
                continue;
            }

            var commitDateKey = commit.Author.When.Date;

            if (!commitsPerDay.ContainsKey(commitDateKey))
            {
                commitsPerDay[commitDateKey] = 1;
            }
            else
            {
                commitsPerDay[commitDateKey]++;
            }

        }

        foreach (var commitDate in commitsPerDay)
        {
            yield return (commitDate.Key, commitDate.Value);
        }
    }

}
