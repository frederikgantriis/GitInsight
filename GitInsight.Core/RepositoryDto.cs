namespace GitInsight.Core;

public record RepositoryDto(int Id, Uri url, int lastCommitId);

public record RepositoryCreateDto(Uri url);

public record RepositoryUpdateDto(int Id, int lastCommitId);
