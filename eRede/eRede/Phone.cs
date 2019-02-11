namespace eRede
{
    public class Phone
    {
        public const string CELLPHONE = "1";
        public const string HOME = "2";
        public const string WORK = "3";
        public const string OTHER = "4";

        public Phone(string ddd, string number, string type = CELLPHONE)
        {
            this.ddd = ddd;
            this.number = number;
            this.type = type;
        }

        public string ddd { get; set; }
        public string number { get; set; }
        public string type { get; set; }
    }
}