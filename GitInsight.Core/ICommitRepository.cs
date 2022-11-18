namespace GitInsight.Core;

public interface ICommitRepository
{
  (Response Response, int commitId) Create(CommitCreateDto commitCreateDto);
  CommitDto Read(int commitId);
  Response Update(CommitUpdateDto commitUpdateDto);
  Response Delete(int commitId);
}