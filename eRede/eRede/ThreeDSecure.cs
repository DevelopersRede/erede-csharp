namespace eRede;

public class ThreeDSecure
{
    public const string DataOnly = "DATA_ONLY";
    public const string MpiRede = "MPI Rede";
    public const string MpiCliente = "MPI Cliente";

    public const string ContinueOnFailure = "continue";
    public const string DeclineOnFailure = "decline";

    public ThreeDSecure()
    {
        Embedded = true;
    }

    public ThreeDSecure(string mpi)
    {
        Embedded = mpi == MpiRede;
    }

    public string Cavv { get; set; }
    public string Eci { get; set; }
    public bool Embedded { get; set; }
    public string OnFailure { get; set; } = DeclineOnFailure;
    public string Url { get; set; }
    public string UserAgent { get; set; }
    public string Xid { get; set; }
    public Device Device { get; set; }
    public string ReturnCode { get; set; }
    public string ReturnMessage { get; set; }
    public string ThreeDIndicator { get; set; }
    public string DirectoryServerTransactionId { get; set; }
    public string challengePreference { get; set; }
}