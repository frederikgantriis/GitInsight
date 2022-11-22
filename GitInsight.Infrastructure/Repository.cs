namespace GitInsight.Infrastructure;

public class Repository
{
  public int Id { get; set; }
  public Uri url { get; set; }
  public int lastCommitId { get; set; }
}
