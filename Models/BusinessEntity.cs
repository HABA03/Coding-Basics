using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Person.BusinessEntity")]
public class BusinessEntity
{
    [Key]
    public int BusinessEntityID { get; set; }
    public Person? Person { get; set; }
    public Store? Store { get; set; }
    public SalesPerson? SalesPerson { get; set; }
}
