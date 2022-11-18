namespace GitInsight.Core;

public record UserDto(int Id, string Name);

public record UserCreateDto([StringLenght(50)] string name);

public record UserUpdateDto(int Id, [StringLenght(50)] string Name);
