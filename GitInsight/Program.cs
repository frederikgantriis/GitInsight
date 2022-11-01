﻿namespace GitInsight;

using LibGit2Sharp;
using System.Globalization;
using CommandLine;

public class Program
{
    public class Options
    {
        [Option('a', "author", Required = false, HelpText = "Display commits categorized by author.")]
        public bool Author { get; set; }

    }
    private static void Main(string[] args)
    {
        Parser.Default.ParseArguments<Options>(args)
          .WithParsed<Options>(o =>
          {
              if (o.Author)
              {
                  //TODO: Implement method that Format output with author
                  Console.WriteLine($"Author mode.");
              }
              else
              {
                  Console.WriteLine("Commit frequency mode");
                  var dateFormat = "dd-MM-yyyy";
                  foreach ((DateTime date, int amount) in CommitTracker.getCommitsPerDay(@"../.git", "Frederik Gantriis Møller"))
                  {
                    Console.WriteLine($"{date.ToString(dateFormat, CultureInfo.InvariantCulture)} {amount}");
                  }
              }
          });
    }
}
