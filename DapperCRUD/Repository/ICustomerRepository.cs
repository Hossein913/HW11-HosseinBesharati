using DapperCRUD.Models;

namespace DapperCRUD.Repository
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(int id);
        Task Create(Customer _Customer);
        Task Update(Customer _Customer);
        Task Delete(int id);
    }
}
