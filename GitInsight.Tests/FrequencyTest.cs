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

    [Fact]
    public void Given_no_Author_Then_Outputs_All_Commits_Per_Date()
    {

        var date = new DateTimeOffset(new DateTime(2000, 10, 20));
        var signature = new Signature("Magnus Larsen", "magnus@larsen.dk", date);
        _testRepo.Commit("besked", signature, signature, new CommitOptions() { AllowEmptyCommit= true});
        
        var result = _tracker.GetCommitsPerDay().First();
        result.Should().Be((new DateTime(2000, 10, 20), 1));
    }

    //TODO: mange commits på en dato

    public void Dispose()
    {
        _testRepo.Dispose();
        //Directory.Delete(_path, recursive: true);
    }
}