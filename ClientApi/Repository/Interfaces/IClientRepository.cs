using ClientApi.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientApi.Repository.Interfaces
{
    public interface IClientRepository
    {
        Task<List<ClientDomainModel>> GetAllAsync();
        Task<ClientDomainModel> GetByIdAsync(ClientDomainModel model);
        Task DeleteAsync(ClientDomainModel model);
        Task<ClientDomainModel> CreateAsync(ClientDomainModel model);
        Task<ClientDomainModel> UpdateAsync(ClientDomainModel model);
        Task<ClientDomainModel> GetByAttendeeIdAsync(ClientDomainModel model);
    }
}
