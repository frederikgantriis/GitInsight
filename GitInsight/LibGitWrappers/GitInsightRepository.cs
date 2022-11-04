namespace GitInsight;

using LibGit2Sharp;

public class GitInsightRepository 
{
    // private IRepository _repository;
    private List<GitInsightCommit> _commits;

    public GitInsightRepository(IRepository repository)
    {
        // _repository = repository;
        _commits = repository.Commits.Select(c => new GitInsightCommit(c)).ToList();
    }

    public IEnumerable<GitInsightCommit> Commits{ get{return _commits; } }
}