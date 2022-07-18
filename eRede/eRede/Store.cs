namespace eRede;

public class Store
{
    public Store(string filliation, string token) : this(filliation, token, Environment.Production())
    {
    }

    public Store(string filliation, string token, Environment environment)
    {
        Environment = environment;
        Filliation = filliation;
        Token = token;
    }

    public Environment Environment { get; }
    public string Filliation { get; }
    public string Token { get; }
}