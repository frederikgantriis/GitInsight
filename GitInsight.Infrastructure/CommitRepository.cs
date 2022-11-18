namespace GitInsight.Infrastructure;

public class CommitRepository : ICommitRepository 
{ 

    private readonly GitInsightDbContext _dbContext;

    public CommitRepository(GitInsightDbContext dbContext)
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