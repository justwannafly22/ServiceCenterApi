using Database.Domain;

namespace Database.Infrastructure
{
    public interface IClientRepositoryFactory
    {
        ClientDomainModel ToDomain(Client client);
        Client ToClient(ClientDomainModel model);
    }
}
