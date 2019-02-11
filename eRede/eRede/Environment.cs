namespace eRede
{
    public class Environment
    {
        private const string PRODUCTION = "https://api.userede.com.br/erede";
        private const string SANDBOX = "https://api.userede.com.br/desenvolvedores";
        private const string VERSION = "v1";

        private Environment(string baseUrl, string version)
        {
            endpoint = $"{baseUrl}/{version}/";
        }

        public string ip { get; set; }
        public string sessionId { get; set; }

        private string endpoint { get; }

        public static Environment Production()
        {
            return new Environment(PRODUCTION, VERSION);
        }

        public static Environment Sandbox()
        {
            return new Environment(SANDBOX, VERSION);
        }

        public string Endpoint(string service)
        {
            return endpoint + service;
        }
    }
}