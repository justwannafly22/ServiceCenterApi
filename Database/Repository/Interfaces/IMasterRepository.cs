using Database.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database
{
    public interface IMasterRepository
    {
        Task<MasterDomainModel> CreateAsync(MasterDomainModel model);
        Task DeleteAsync(MasterDomainModel model);
        Task<List<MasterDomainModel>> GetAllAsync();
        Task<MasterDomainModel> GetByIdAsync(MasterDomainModel model);
        Task<MasterDomainModel> UpdateAsync(MasterDomainModel model);
        Task<MasterDomainModel> GetByAttendeeIdAsync(MasterDomainModel model);
    }
}
