using Database.Domain;

namespace Database
{
    public interface IMasterRepositoryFactory
    {
        Master ToEntity(MasterDomainModel model);
        MasterDomainModel ToDomain(Master model);
    }
}
