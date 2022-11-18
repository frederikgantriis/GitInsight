namespace GitInsight.Infrastructure;

public class CommitRepository : ICommitRepository 
{ 

    private readonly GitInsightDbContext _dbContext;

    public CommitRepository(GitInsightDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    (Response Response, int commitId) Create(CommitCreateDto commitCreateDto)
    {
        throw new NotImplementedException();
    }
    CommitDto Read(int commitId)
    {
        throw new NotImplementedException();
    }
    Response Update(CommitUpdateDto commitUpdateDto)
    {
        throw new NotImplementedException();
    }
    Response Delete(int commitId)
    {
        throw new NotImplementedException();
    }

} 