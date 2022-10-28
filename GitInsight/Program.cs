//namespace GitInsight;

using LibGit2Sharp;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("lsjfakl");

        using (var repo = new Repository(@"..\.git"))
        {
            foreach (var commit in repo.Commits)
            {
              Console.WriteLine(commit);
            }
        }
    }

    public void frequencyCommit() {
        
    }
}
