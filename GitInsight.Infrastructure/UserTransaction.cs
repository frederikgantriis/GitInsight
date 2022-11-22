namespace GitInsight.Infrastructure;

public class UserTransaction : IUserTransaction
{
    private readonly GitInsightContext _dbContext;

    public UserTransaction(GitInsightContext dbContext)
    {
        _dbContext = dbContext;
    }

    public (Response Response, int userId) Create(UserCreateDto userCreateDto)
    {
        throw new NotImplementedException();
    }

    public UserDto Read(int userId)
    {
        throw new NotImplementedException();
    }

    public Response Update(int repoId, int lastCommitId)
    {
        throw new NotImplementedException();
    }

    public Response Delete(int userId)
    {
        throw new NotImplementedException();
    }
}