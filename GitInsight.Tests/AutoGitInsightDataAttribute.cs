namespace GitInsight.Tests;


public class AutoGitInsightDataAttribute : AutoDataAttribute
{
    public AutoGitInsightDataAttribute() :
        base(() => new Fixture().Customize(new AutoMoqCustomization()))
    { }
}