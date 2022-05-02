using MasterApi.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasterApi.Repository
{
    public interface IMasterRepository
    {
        Task<MasterDomainModel> CreateAsync(MasterDomainModel model);
        Task DeleteAsync(MasterDomainModel model);
        Task<List<MasterDomainModel>> GetAllAsync();
        Task<MasterDomainModel> GetByIdAsync(MasterDomainModel model);
        Task<MasterDomainModel> UpdateAsync(MasterDomainModel model);
    }
}
