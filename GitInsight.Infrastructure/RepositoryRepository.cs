namespace GitInsight.Infrastructure;

public class RepositoryRepository : IRepositoryRepository
{
    private readonly GitInsightDbContext _dbContext;

    public RepositoryRepository(GitInsightDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    (Response Response, int repositoryId) Create(RepositoryCreateDto repositoryCreateDto)
    {
        throw new NotImplementedException();
    }
    RepositoryDto Read(int repositoryId)
    {
        throw new NotImplementedException();
    }
    Response Update(RepositoryUpdateDto repositoryUpdateDto)
    {
        throw new NotImplementedException();
    }
    Response Delete(int repositoryId)
    {
        throw new NotImplementedException();
    }
}