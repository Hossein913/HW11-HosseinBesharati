using DapperCRUD.Models;

namespace DapperCRUD.Repository
{
    public interface IAddressRepository
    {
        Task<IEnumerable<Address>> GetByCustomer(int id);
        Task Create(Address _address);
        Task Update(Address _address);
        Task Delete(int id);
    }
}
