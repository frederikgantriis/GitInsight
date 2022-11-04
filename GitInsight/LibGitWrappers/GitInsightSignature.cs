namespace GitInsight;

using LibGit2Sharp;
public class GitInsightSignature
{

    string _name;
    string _email;
    DateTimeOffset _when;
    public GitInsightSignature(Signature signature)
    {
        _name = signature.Name;
        _email = signature.Email;
        _when = signature.When;
    }

    public DateTimeOffset When { get { return _when; } }
    public String Name { get { return _name; }}
}