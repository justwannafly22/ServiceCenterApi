using Database.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database
{
    public interface IProductRepository
    {
        Task<List<ProductDomainModel>> GetAllAsync();
        Task<ProductDomainModel> GetByIdAsync(ProductDomainModel model);
        Task<ProductDomainModel> CreateAsync(ProductDomainModel model);
        Task<ProductDomainModel> UpdateAsync(ProductDomainModel model);
        Task DeleteAsync(ProductDomainModel model);
    }
}
