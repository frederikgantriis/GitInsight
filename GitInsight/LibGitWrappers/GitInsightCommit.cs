namespace GitInsight;

using LibGit2Sharp;

public class GitInsightCommit
{
    Commit _commit;
    GitInsightSignature _signature;

    public GitInsightCommit(Commit commit)
    {
        _commit = commit;
        _signature = new GitInsightSignature(commit.Author);
    }

    public GitInsightSignature Author { get { return _signature; } }

}