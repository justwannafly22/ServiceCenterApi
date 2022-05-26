using RepairApi.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepairApi.Repository.Interfaces
{
    public interface IRepairRepository
    {
        Task<List<RepairDomainModel>> GetAllAsync();
        Task<RepairDomainModel> GetByIdAsync(RepairDomainModel model);
        Task<RepairDomainModel> UpdateAsync(RepairDomainModel model);
        Task DeleteAsync(RepairDomainModel model);
        Task<RepairDomainModel> CreateAsync(RepairDomainModel model);
    }
}
