namespace eRede
{
    public class Store
    {
        public Store(string filliation, string token) : this(filliation, token, Environment.Production())
        {
        }

        public Store(string filliation, string token, Environment environment)
        {
            this.environment = environment;
            this.filliation = filliation;
            this.token = token;
        }

        public Environment environment { get; }
        public string filliation { get; }
        public string token { get; }
    }
}