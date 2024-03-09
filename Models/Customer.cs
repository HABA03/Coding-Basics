using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Sales.Customer")]
public class Customer
{
        [Key]
        public int CustomerID { get; set; }
        public int PersonID { get; set; }

        [ForeignKey("PersonID")]
        public Person? Person { get; set; }
}
