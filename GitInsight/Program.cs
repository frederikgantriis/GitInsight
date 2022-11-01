namespace GitInsight;

using LibGit2Sharp;
using System.Globalization;

public class Program
{
  private static void Main(string[] args)
  {
    //TODO: Implement method that Format output with author
    CommitTracker.getCommitsPerDay(@"../.git", "Frederik Gantriis Møller").ToList().ForEach(Console.WriteLine);
  }
}
