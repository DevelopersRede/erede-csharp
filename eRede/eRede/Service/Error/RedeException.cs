using System;

namespace eRede.Service.Error
{
    public class RedeException : Exception
    {
        public RedeError error { get; set; }
    }
}