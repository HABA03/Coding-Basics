using System.ComponentModel.DataAnnotations.Schema;

[Table("Person.Address")]
public class Address
{
    public int? AddressID {get;set;}
    public string? AddressLine1 {get;set;}
    public string? AddressLine2 {get;set;}
    public string? City {get;set;}
    public int? StateProvinceID {get;set;}
    public string? PostalCode {get;set;}
}
