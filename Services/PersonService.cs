using System.Data;
using Microsoft.EntityFrameworkCore;

public class PersonService : IPersonRepository
{
    private readonly Context _context;
    public PersonService(Context context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Person>> GetAll()
    {
        var response = await _context.PersonPerson
            .Include( x => x.Employee)
            .Include( x => x.Address)
            .Include( x => x.EmailAddress)
            .Include( x => x.PersonPhone)
            .ToListAsync();
        return response;
    }

    public async Task<Person> GetPersonByName(string name)
    {
        if(name != null)
        {
            var response = await _context.PersonPerson
                .Include(x => x.Employee)
                .Include( x => x.Address)
                .Include( x => x.EmailAddress)
                .Include( x => x.PersonPhone)
                .Where(x => x.FirstName == name)
                .FirstOrDefaultAsync();

            return response;
        }else
        {
            return null;
        }
    }

    public async Task<IEnumerable<Person>> GetPersonByNameAndPersonType(string name, string personType)
    {
        try
        {
            var response = await _context.PersonPerson
                .Include(e => e.Address)
                .Include(e => e.EmailAddress)
                .Include(e => e.Employee)
                .Include(e => e.PersonPhone)
                .Where(e => e.PersonType == personType && e.FirstName == name)
                .ToListAsync();
            
            return response;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error message: {ex.Message}");
            return null;
        }
    }

    public async Task<IEnumerable<Person>> GetPersonByPersonType(string personType)
    {
        try
        {
            var response = await _context.PersonPerson
                .Include(e => e.Address)
                .Include(e => e.EmailAddress)
                .Include(e => e.Employee)
                .Include(e => e.PersonPhone)
                .Where(e => e.PersonType == personType)
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

