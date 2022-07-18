using System.Collections.Generic;

namespace eRede;

public class Customer
{
    public const string Male = "S";
    public const string Female = "M";

    public string Cpf { get; set; }
    public List<Document> Documents { get; set; }
    public string Email { get; set; }

    public string Name { get; set; }
    public string Gender { get; set; }
    public Phone Phone { get; set; }

    private void PrepareDocuments()
    {
        Documents ??= new List<Document>();
    }


    public Customer AddDocument(string type, string number)
    {
        PrepareDocuments();

        Documents.Add(new Document { Type = type, Number = number });

        return this;
    }

    public List<Document>.Enumerator GetEnumerator()
    {
        PrepareDocuments();

        return Documents.GetEnumerator();
    }
}