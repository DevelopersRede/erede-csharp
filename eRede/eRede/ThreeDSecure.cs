namespace eRede
{
    public class ThreeDSecure
    {
        public const string CONTINUE_ON_FAILURE = "continue";
        public const string DECLINE_ON_FAILURE = "decline";

        public string cavv { get; set; }
        public string eci { get; set; }
        public bool embedded { get; set; }
        public string onFailure { get; set; }
        public string url { get; set; }
        public string userAgent { get; set; }
        public string xid { get; set; }
    }
}