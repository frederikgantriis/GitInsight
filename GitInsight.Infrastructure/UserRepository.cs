namespace GitInsight.Infrastructure;

public class UserRepository : IUserRepository
{
    private readonly GitInsightDbContext _dbContext;

    public UserRepository(GitInsightDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    (Response Response, int userId) IUserRepository.Create(UserCreateDto userCreateDto)
    {
        throw new NotImplementedException();
    }

    UserDto IUserRepository.Read(int userId)
    {
        throw new NotImplementedException();
    }

    public Response Update(int repoId, int lastCommitId)
    {
        throw new NotImplementedException();
    }

    Response IUserRepository.Delete(int userId)
    {
        throw new NotImplementedException();
    }
}