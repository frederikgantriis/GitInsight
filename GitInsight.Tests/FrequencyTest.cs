namespace GitInsight.Tests;

using GitInsight;
using LibGit2Sharp;
using FluentAssertions;

public class FrequencyTest : IDisposable
{

    Repository _testRepo;
    CommitTracker _tracker;
    string _path;
    public FrequencyTest() 
    {
        _path = @"../TestRepo";
        Repository.Init(_path);
        _testRepo = new Repository(_path);
        _tracker = new CommitTracker(_testRepo);
    }

    [Theory]
    [InlineData("Magnus Larsen", "magnus@larsen.dk", "2022-11-08" )]
    [InlineData("Katrine Meyer", "Katrine@Meyer.dk", "2022-11-07")]
    public void Given_no_Author_Then_Outputs_All_Commits_Per_Date(string name, string mail, string date)
    {
        var parsedDate = DateTime.Parse(date);
        var signature = new Signature(name, mail, parsedDate);
        _testRepo.Commit("besked",  signature, signature, new CommitOptions() { AllowEmptyCommit= true});
        
        var result = _tracker.GetCommitsPerDay().First();  //returns a list
        var expected = (parsedDate, 1);
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("Magnus Larsen", "magnus@larsen.dk", "2022-11-08")]
    [InlineData("Katrine Meyer", "Katrine@Meyer.dk", "2022-11-07")]
    public void Given_a_Author_Then_Outputs_All_Commits_Per_Date(string name, string mail, string date)
    {
        var parsedDate = DateTime.Parse(date);
        var signature = new Signature(name, mail, parsedDate);
        _testRepo.Commit("besked",  signature, signature, new CommitOptions() { AllowEmptyCommit= true});
        
        var result = _tracker.GetCommitsByAuthor();  //returns a list

        List<(string, List<(DateTime, int)>)> expected = new List<(string, List<(DateTime, int)>)>();
        expected.Add((name, new List<(DateTime, int)>{(parsedDate, 1)}));
        result.Should().BeEquivalentTo(expected);
    }


    public void Dispose()
    {
        _testRepo.Dispose();
        Directory.Delete(_path, recursive: true);
    }
}