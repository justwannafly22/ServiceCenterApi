using ReplacedPartApi.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReplacedPartApi.Repository.Interfaces
{
    public interface IReplacedPartRepository
    {
        Task<ReplacedPartDomainModel> CreateAsync(ReplacedPartDomainModel model);
        Task<ReplacedPartDomainModel> UpdateAsync(ReplacedPartDomainModel model);
        Task<ReplacedPartDomainModel> GetByIdAsync(ReplacedPartDomainModel model);
        Task DeleteAsync(ReplacedPartDomainModel model);
        Task<List<ReplacedPartDomainModel>> GetAllByRepairIdAsync(Guid repairId);
        Task<List<ReplacedPartDomainModel>> GetAllByProductIdAsync(Guid productId);
    }
}
