namespace GitInsight.Infrastructure;

public class CommitTransaction : ICommitTransaction 
{ 

    private readonly GitInsightContext _dbContext;

    public CommitTransaction(GitInsightContext dbContext)
    {
        _dbContext = dbContext;
    }

    public (Response Response, int commitId) Create(CommitCreateDto commitCreateDto)
    {
        throw new NotImplementedException();
    }

    public Response Delete(int commitId)
    {
        throw new NotImplementedException();
    }

    public CommitDto Read(int commitId)
    {
        throw new NotImplementedException();
    }

    public Response Update(CommitUpdateDto commitUpdateDto)
    {
        throw new NotImplementedException();
    }
}