namespace eRede
{
    public class Url
    {
        public const string Callback = "callback";
        public const string THREE_D_SECURE_FAILURE = "threeDSecureFailure";
        public const string THREE_D_SECURE_SUCCESS = "threeDSecureSuccess";

        public string kind { get; set; }
        public string type { get; set; }
        public string url { get; set; }
    }
}