namespace GitInsight;

using LibGit2Sharp;

public class GitInsightRepository 
{
    private IRepository _repository;
    private List<Commit> _commits;

    public GitInsightRepository(IRepository repository)
    {
        _repository = repository;
        _commits = _repository.Commits.ToList();
    }

    public IEnumerable<Commit> Commits{ get; }
}