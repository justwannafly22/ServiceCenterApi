using RepairApi.Domain;
using RepairApi.Repository.Entities;
using System;

namespace RepairApi.Factories
{
    public class RepositoryFactory : IRepositoryFactory
    {
        public RepairDomainModel ToDomain(Repair model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return new RepairDomainModel
            {
                Id = model.Id,
                Name = model.Name,
                Date = model.RepairInfo.Date,
                AdvancedInfo = model.RepairInfo.AdvancedInfo,
                Status = model.RepairInfo.Status.StatusInfo,
                MasterId = model.MasterId,
                ClientId = model.ClientId
            };
        }

        public Repair ToEntity(RepairDomainModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return new Repair
            {
                Id = model.Id,
                Name = model.Name,
                RepairInfo = new RepairInfo
                { 
                    Date = model.Date,
                    AdvancedInfo = model.AdvancedInfo,
                    Status = new Status
                    {
                        StatusInfo = model.Status
                    }
                },
                MasterId = model.MasterId,
                ClientId = model.ClientId
            };
        }
    }
}
