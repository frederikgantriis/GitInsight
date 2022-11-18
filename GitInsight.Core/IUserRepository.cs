namespace GitInsight.Core;

public interface IUserRepository
{
    (Response Response, int userId) Create(UserCreateDto userCreateDto);
    UserDto Read(int userId);
    Response Update(UserUpdateDto userUpdateDto);
    Response Delete(int userId);
}