namespace GitInsight.Infrastructure;

public class RepositoryTransaction : IRepositoryTransaction
{
    private readonly GitInsightContext _dbContext;

    public RepositoryTransaction(GitInsightContext dbContext)
    {
        _dbContext = dbContext;
    }

    public (Response Response, int repositoryId) Create(RepositoryCreateDto repositoryCreateDto)
    {
        throw new NotImplementedException();
    }

    public Response Delete(int repositoryId)
    {
        throw new NotImplementedException();
    }

    public RepositoryDto Read(int repositoryId)
    {
        throw new NotImplementedException();
    }

    public Response Update(RepositoryUpdateDto repositoryUpdateDto)
    {
        throw new NotImplementedException();
    }
}