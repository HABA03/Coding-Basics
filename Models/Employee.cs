using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("HumanResources.Employee")]
public class Employee
{
      public int? BusinessEntityID { get; set; }
      public string? JobTitle{ get; set; }
}