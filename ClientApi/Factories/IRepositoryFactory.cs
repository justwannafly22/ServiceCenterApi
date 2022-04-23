using ClientApi.Domain;
using ClientApi.Repository.Entities;

namespace ClientApi.Factories
{
    public interface IRepositoryFactory
    {
        ClientDomainModel ToDomain(Client client);
        Client ToClient(ClientDomainModel model);
    }
}
