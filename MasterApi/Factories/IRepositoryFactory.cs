using MasterApi.Domain;
using MasterApi.Repository;

namespace MasterApi.Factories
{
    public interface IRepositoryFactory
    {
        Master ToEntity(MasterDomainModel model);
        MasterDomainModel ToDomain(Master model);
    }
}
