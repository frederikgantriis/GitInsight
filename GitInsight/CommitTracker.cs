namespace GitInsight;

using LibGit2Sharp;
public class CommitTracker
{
    IRepository _repository;
    public CommitTracker(IRepository repository)
    {
        _repository = repository;
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
        var authors = _repository.Commits.Select(c => c.Author).DistinctBy(c => c.Email);

        foreach (var author in authors)
        {
            var authorCommits = _repository.Commits.Where(c => c.Author.Email == author.Email);
            yield return (author.Name, GetCommitsPerDay(authorCommits));
        }
    }

}
