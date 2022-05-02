using MasterApi.Domain;
using MasterApi.Repository;
using System;

namespace MasterApi.Factories
{
    public class RepositoryFactory : IRepositoryFactory
    {
        public MasterDomainModel ToDomain(Master model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return new MasterDomainModel
            {
                Id = model.Id,
                Name = model.Name,
                Surname = model.Surname,
                Age = model.Age,
                ContactNumber = model.ContactNumber
            };
        }

        public Master ToEntity(MasterDomainModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return new Master
            {
                Id = model.Id,
                Name = model.Name,
                Surname = model.Surname,
                Age = model.Age,
                ContactNumber = model.ContactNumber
            };
        }
    }
}
