using RepairApi.Domain;
using RepairApi.Repository.Entities;

namespace RepairApi.Factories
{
    public interface IRepositoryFactory
    {
        Repair ToEntity(RepairDomainModel model);
        RepairDomainModel ToDomain(Repair model);
    }
}
