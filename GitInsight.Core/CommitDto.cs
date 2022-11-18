namespace GitInsight.Core;

public record CommitDto(int Id, int User_Id, int Repo_Id, DateTime date);

public record CommitCreateDto(int User_Id, int Repo_Id, DateTime date);

public record CommitUpdateDto(int Id, int User_Id, int Repo_Id, DateTime date);
