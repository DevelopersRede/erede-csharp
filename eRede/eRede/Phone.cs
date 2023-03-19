namespace eRede;

public class Phone
{
    public const string Cellphone = "1";
    public const string Home = "2";
    public const string Work = "3";
    public const string Other = "4";

    public Phone(string ddd, string number, string type = Cellphone)
    {
        Ddd = ddd;
        Number = number;
        Type = type;
    }

    public string Ddd { get; }
    public string Number { get; }
    public string Type { get; }
}