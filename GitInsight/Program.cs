namespace GitInsight;

using LibGit2Sharp;
using System.Globalization;

public class Program
{
    private static void Main(string[] args)
    {
        //TODO: Implement method that Format output with author
        getCommitsPerDay(@"../.git", "Frederik Gantriis Møller").ToList().ForEach(Console.WriteLine);



    }

    
    /// <summary>
    /// This method returns a formatted string of commits per day, optionally only by a single author
    /// </summary>
    /// <param name="path">path to a local git repository</param>
    /// <param name="author">optional: only get commits by author</param>
    public static IEnumerable<string> getCommitsPerDay(string path, string author = "")
    {
        IDictionary<string, int> commitsPerDay = new Dictionary<string, int>();
        using (var repo = new Repository(path))
        {
            var dateFormat = "dd-MM-yyyy";

            foreach (var commit in repo.Commits)
            {
                var commitDateKey = commit.Author.When.Date.ToString(dateFormat, CultureInfo.InvariantCulture);

                if (author != "" && author != commit.Author.Name)
                {
                    continue;
                }

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
                yield return $"{commitDate.Key} {commitDate.Value}";
            }
        }
    }
}