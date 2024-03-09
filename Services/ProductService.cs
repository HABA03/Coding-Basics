using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
public class ProductService : IProdutRepository
{
    private readonly Context _context;
    public ProductService(Context context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        var response = await _context.ProductionProduct
            .Include(e => e.ProductCategory)
            .ToListAsync();
        
        return response;
    }

    public async Task<Product> GetProductByName(string name)
    {
        try
        {
            var response = await _context.ProductionProduct
                .Include(e => e.ProductCategory)
                .Where(e => e.Name == name)
                .FirstOrDefaultAsync();

            return response;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error message: {ex.Message}");
            return null;
        }
    }

    public async Task<IEnumerable<Product>> GetProductsByCategoryType(string categoryType)
    {
        try
        {
            var response = await _context.ProductionProduct
                .Include(e => e.ProductCategory)
                .Where(e => e.ProductCategory.Name == categoryType)
                .ToListAsync();

            return response;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error message: {ex.Message}");
            return null;
        }
    }
}
