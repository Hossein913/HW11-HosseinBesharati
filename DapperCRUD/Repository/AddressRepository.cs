using Dapper;
using DapperCRUD.Data;
using DapperCRUD.Models;
using System.Data;

namespace DapperCRUD.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly IDapperContext _context;
        public AddressRepository(IDapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Address>> GetByCustomer(int id)
        {
            var query = "select * from [Address] WHERE CustomerId = @id";

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<Address>(query, new { id });
                return result;
            }
        }

        public async Task Create(Address _address)
        {
            var query = "INSERT INTO " + typeof(Address).Name + " ([Address],[CustomerId]) VALUES (@Address, @CustomerId)";
            var parameters = new DynamicParameters();
            parameters.Add("Address", _address.address, DbType.String);
            parameters.Add("CustomerId", _address.CustomerId, DbType.Int32);
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }


        public async Task Update(Address _address)
        {
            var query = "UPDATE Address SET [Address]=@Address ,[CustomerId]=@CustomerId  WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", _address.Id, DbType.Int32);
            parameters.Add("Address", _address.address, DbType.String);
            parameters.Add("CustomerId", _address.CustomerId, DbType.Int32);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }


        public async Task Delete(int id)
        {
            var query = "DELETE FROM " + typeof(Address).Name + " WHERE Id = @id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }
    }
}
