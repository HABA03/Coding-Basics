using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Person.Person")]
public class Person 
{
    [Key]
    public int BusinessEntityID {get;set;}
    public string? Title {get;set;}
    public string? PersonType {get;set;}
    public string? FirstName {get;set;}
    public string? MiddleName {get;set;}
    public string? LastName {get;set;}
    public string? Suffix {get;set;}
    public int EmailPromotion {get;set;}
    public string? AdditionalContactInfo {get;set;} 
    public Employee? Employee {get; set;}
    public Address? Address { get; set; }
    public PersonPhone? PersonPhone {get;set;}
    public EmailAddresses? EmailAddress {get;set;}
}