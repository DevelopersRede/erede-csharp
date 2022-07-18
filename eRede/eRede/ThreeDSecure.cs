namespace eRede;

public class ThreeDSecure
{
    public const string ContinueOnFailure = "continue";
    public const string DeclineOnFailure = "decline";

    public string Cavv { get; set; }
    public string Eci { get; set; }
    public bool Embedded { get; set; }
    public string OnFailure { get; set; }
    public string Url { get; set; }
    public string UserAgent { get; set; }
    public string Xid { get; set; }
}