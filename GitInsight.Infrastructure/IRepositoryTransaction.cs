namespace GitInsight.Core;

public interface IRepositoryTransaction
{
    (Response Response, int repositoryId) Create(RepositoryCreateDto repositoryCreateDto);
    RepositoryDto Read(int repositoryId);
    Response Update(RepositoryUpdateDto repositoryUpdateDto); 
    Response Delete(int repositoryId);
}