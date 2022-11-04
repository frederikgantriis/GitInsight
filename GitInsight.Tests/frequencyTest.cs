namespace GitInsight.Tests;

using GitInsight;
using Moq;
using LibGit2Sharp;

public class frequencyTest
{

    //TODO: Implement Tests for Frequency Commits
    [Fact]
    public void Given_no_Author_Then_Outputs_All_Commits_Per_Date()
    {
        //Arange
        var repo = new Repository();
        var insightRepoMock = new Mock<GitInsightRepository>(repo)
            .Setup(r => r.Commits)
            .Returns(new List<GitInsightCommit>());
        // var tracker = new CommitTracker(insightRepoMock);

        //Act
        // var result = tracker.getCommitsPerDay();

        //Assert

    }
}