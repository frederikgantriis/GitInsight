namespace GitInsight.Core;

public record UserDto(int Id, string Name);

public record UserCreateDto([StringLength(50)] string name);

public record UserUpdateDto(int Id, [StringLength(50)] string Name);
