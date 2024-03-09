using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public interface IProdutRepository
{
    Task<IEnumerable<Product>> GetAll();
    Task<Product> GetProductByName(string name);
    Task<IEnumerable<Product>> GetProductsByCategoryType(string categoryType);
}