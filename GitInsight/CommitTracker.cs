namespace GitInsight;

using LibGit2Sharp;
using System.Globalization;
using CommandLine;
using System.Diagnostics.CodeAnalysis;
public class CommitTracker
{
    IRepository _repository;
    public CommitTracker(IRepository repository)
    {
        _repository = repository;
    }

    [ExcludeFromCodeCoverage]
    public class Options
    {
        [Option('a', "author", Required = false, HelpText = "Display commits categorized by author.")]
        public bool Author { get; set; }

    }
    public static void StartUp(string[] args)
    {


        var repository = new Repository(@"../.git"); //TODO: perhaps from options class
        var tracker = new CommitTracker(repository);

        Parser.Default.ParseArguments<Options>(args)
        .WithParsed<Options>(o =>
        {
            if (o.Author)
            {
                foreach ((string author, var commits) in tracker.GetCommitsByAuthor())
                {
                    Console.WriteLine(author);
                    foreach ((var date, int amount) in commits)
                    {
                        Console.WriteLine($"    {FormatDateAndAmount(date, amount)}");
                    }
                }
            }
            else
            {
                foreach ((DateTime date, int amount) in tracker.GetCommitsPerDay())
                {
                    Console.WriteLine(FormatDateAndAmount(date, amount));
                }
            }
        });
    }

    /// <summary>
    /// This method returns a formatted string of commits per day, optionally only by a single author
    /// </summary>
    /// <param name="path">path to a local git repository</param>
    /// <param name="author">optional: only get commits by author</param>
    public IEnumerable<(DateTime, int)> GetCommitsPerDay()
    {
        return GetCommitsPerDay(_repository.Commits);
    }

    public IEnumerable<(DateTime, int)> GetCommitsPerDay(IEnumerable<Commit> commits)
    {
        return _repository.Commits
            .GroupBy(c => c.Author.When.Date)
            .Select(c => (c.Key, c.Count()));
    }

    public IEnumerable<(string Author, IEnumerable<(DateTime, int)>)> GetCommitsByAuthor()
    {
        var authors = _repository.Commits.Select(c => c.Author.Name).Distinct();

        foreach (var author in authors)
        {
            //Should maybe be by email
            var authorCommits = _repository.Commits.Where(c => c.Author.Name == author);
            yield return (author, GetCommitsPerDay(authorCommits));
        }
    }

    private static string FormatDateAndAmount(DateTime date, int amount)
    {
        var dateFormat = "dd-MM-yyyy";
        return $"{date.ToString(dateFormat, CultureInfo.InvariantCulture)} {amount}"; 
    }

}
