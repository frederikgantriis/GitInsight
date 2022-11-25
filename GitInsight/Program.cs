//dotnet run --a (author mode)
namespace GitInsight;

using System.Globalization;
using CommandLine;
using System.Diagnostics.CodeAnalysis;
using GitInsight.Services;


[ExcludeFromCodeCoverage]
public class Program
{
  public class Options
  {
    [Option('a', "author", Required = false, HelpText = "Display commits categorized by author.")]
    public bool Author { get; set; }

  }

  private static void Main(string[] args)
  {

    var repository = new LibGit2Sharp.Repository(@"../.git");
    var tracker = new CommitService(repository);

    Parser.Default.ParseArguments<Options>(args)
    .WithParsed<Options>(o =>
    {
      if (o.Author)
      {
        foreach ((string author, var commits) in tracker.GetCommitsByAuthor())
        {
          Console.WriteLine(author);
          foreach ((var date, int amount) in commits)
          {
            Console.WriteLine($"    {FormatDateAndAmount(date, amount)}");
          }
        }
      }
      else
      {
        foreach ((DateTime date, int amount) in tracker.GetCommitsPerDay())
        {
          Console.WriteLine(FormatDateAndAmount(date, amount));
        }
      }
    });

  }

  private static string FormatDateAndAmount(DateTime date, int amount)
  {
    var dateFormat = "dd-MM-yyyy";
    return $"{date.ToString(dateFormat, CultureInfo.InvariantCulture)} {amount}";
  }
}
