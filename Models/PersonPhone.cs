using System.ComponentModel.DataAnnotations.Schema;

[Table("Person.PersonPhone")]
public class PersonPhone
{
    public int? BusinessEntityID {get;set;}
    public string? PhoneNumber {get;set;}
    public int? PhoneNumberTypeID {get;set;}
}