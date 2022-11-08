namespace GitInsight.Models;

public class Commit {
  public int Id {get; set;}
  public int User_Id {get; set;}
  public int Repo_Id{get; set;}
  public DateTime date{get; set;}
}