using Database.Domain;
using System;

namespace Database.Infrastructure
{
    public class MasterRepositoryFactory : IMasterRepositoryFactory
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
                ContactNumber = model.ContactNumber,
                Email = model.Email,
                AttendeeId = model.AttendeeId
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
                ContactNumber = model.ContactNumber,
                Email = model.Email,
                AttendeeId = model.AttendeeId
            };
        }
    }
}
