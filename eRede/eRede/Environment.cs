namespace eRede;

public class Environment
{
    private const string ProductionEndpoint = "https://api.userede.com.br/erede";
    private const string SandboxEndpoint = "https://api.userede.com.br/desenvolvedores";
    private const string Version = "v1";

    private Environment(string baseUrl, string version)
    {
        _endpoint = $"{baseUrl}/{version}/";
    }

    public string Ip { get; set; }
    public string SessionId { get; set; }

    private string _endpoint { get; }

    public static Environment Production()
    {
        return new Environment(ProductionEndpoint, Version);
    }

    public static Environment Sandbox()
    {
        return new Environment(SandboxEndpoint, Version);
    }

    public string Endpoint(string service)
    {
        return _endpoint + service;
    }
}