namespace GitInsight.Infrastructure;

public class UserRepository : IUserRepository
{
    private readonly GitInsightDbContext _dbContext;

    public UserRepository(GitInsightDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    (Response Response, int userId) Create(UserCreateDto userCreateDto)
    {
        throw new NotImplementedException();
    }
    UserDto Read(int userId)
    {
        throw new NotImplementedException();
    }
    Response Update(UserUpdateDto userUpdateDto)
    {
        throw new NotImplementedException();
    }
    Response Delete(int userId)
    {
        throw new NotImplementedException(); 
    }
}