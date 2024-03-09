using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

[Table("Production.Product")]
public class Product
{
        [Key]
        public int ProductID { get; set; }
        public string? Name { get; set; }
        public string? Color { get; set; }
        public string? Class { get; set; }
        public string? Style { get; set; }
        public string? ProductNumber { get; set; }
        public decimal? StandardCost { get; set; }
        public ProductCategory? ProductCategory { get; set; }
}
