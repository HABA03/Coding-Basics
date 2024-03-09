using System.ComponentModel.DataAnnotations.Schema;

[Table("Person.EmailAddress")]
public class EmailAddresses
{
    public int? BusinessEntityID {get;set;}
    public string? EmailAddress {get;set;}
}