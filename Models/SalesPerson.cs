using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Sales.SalesPerson")]
public class SalesPerson
{
    [Key]
    public int BusinessEntityID { get; set; }
    public Decimal SalesYTD { get; set; }
    public Decimal SalesLastYear { get; set; }
}