using Database.Domain;

namespace Database.Infrastructure
{
    public interface IRepairRepositoryFactory
    {
        Repair ToEntity(RepairDomainModel model);
        RepairDomainModel ToDomain(Repair model);
    }
}
