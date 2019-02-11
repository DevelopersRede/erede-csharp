using System.Collections.Generic;

namespace eRede
{
    public class Customer
    {
        public const string MALE = "S";
        public const string FEMALE = "M";

        public string cpf { get; set; }
        public List<Document> documents { get; set; }
        public string email { get; set; }

        public string name { get; set; }
        public string gender { get; set; }
        public Phone phone { get; set; }

        private void PrepareDocuments()
        {
            if (documents == null) documents = new List<Document>();
        }


        public Customer AddDocument(string type, string number)
        {
            PrepareDocuments();

            documents.Add(new Document {type = type, number = number});

            return this;
        }

        public List<Document>.Enumerator getEnumerator()
        {
            PrepareDocuments();

            return documents.GetEnumerator();
        }
    }
}