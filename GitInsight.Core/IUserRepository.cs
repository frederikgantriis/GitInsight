namespace GitInsight.Core;

public interface IUserRepository
{
    (Response Response, int userId) Create(UserCreateDto userCreateDto);
    UserDto Read(int userId);
    Response Update(int repoId, int lastCommitId);
    Response Delete(int userId);
}