namespace eRede;

public class Url
{
    public const string Callback = "callback";
    public const string ThreeDSecureFailure = "threeDSecureFailure";
    public const string ThreeDSecureSuccess = "threeDSecureSuccess";

    public string Kind { get; set; }
    public string Type { get; set; }
    public string url { get; set; }
}