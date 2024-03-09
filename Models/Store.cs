using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Sales.Store")]
public class Store
{
    [Key]
    public int BusinessEntityID { get; set; }
    public string? Name { get; set; }
}
