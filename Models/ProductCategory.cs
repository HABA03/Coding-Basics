using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Production.ProductCategory")]
public class ProductCategory
{
    public int ProductCategoryID { get; set; }
    public string? Name { get; set; }
}
