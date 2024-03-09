public interface ISalesRepository
{
    Task<IEnumerable<BusinessEntity>> GetAll();       
    Task<BusinessEntity> GetByName(string name); 
}
