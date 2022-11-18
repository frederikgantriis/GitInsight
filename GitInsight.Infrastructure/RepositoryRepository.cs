namespace GitInsight.Infrastructure;

public class RepositoryRepository : IRepositoryRepository
{
    private readonly GitInsightDbContext _dbContext;

    public RepositoryRepository(GitInsightDbContext dbContext)
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