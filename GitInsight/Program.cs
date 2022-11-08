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

        var repository = new Repository(@"../.git"); //TODO: perhaps from options class
        var tracker = new CommitTracker(repository);

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
