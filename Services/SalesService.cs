using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

public class SalesService : ISalesRepository
{
    private readonly Context _context;

    public SalesService(Context context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BusinessEntity>> GetAll()
    {
    var response = await _context.BusinessEntity
            .Include(e => e.Person)
            .Include(e => e.SalesPerson)
            .Include(e => e.Store)
            .ToListAsync();
        
        return response;
    }

    public async Task<BusinessEntity> GetByName(string name)
    {
        if(name != null)
        {
            var response = await _context.BusinessEntity
                .Include(e => e.Person)
                .Include(e => e.SalesPerson)
                .Include(e => e.Store)
                .Where(e => e.Person.FirstName == name)
                .FirstAsync();
            return response;
        }else
        {
            return null;
        }
    }
}